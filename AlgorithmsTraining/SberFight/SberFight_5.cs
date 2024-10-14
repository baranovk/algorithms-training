using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AlgorithmsTraining.SberFight
{
    public class SberFight_5
    {
        /*
         * Сегодня на турнире сражаются отважные войны! Начальная турнирная сетка определяется
         * случайным образом, количество участников неизменно равно четырем.

           У каждого бойца есть параметр выносливости. Сражаясь, побеждает тот, у кого этот параметр выше. 
           У победителя отнимается выносливость, равная выносливости противника, после чего боец проходит дальше по турнирной сетке.

           Если во время схватки выносливость бойцов одинакова, то побеждает случайный боец, оставаясь с нулевой выносливостью.
           Учитывая случайность подбора в турнирной сетке, определите для каждого участника шанс победить в турнире.

           Ввод:

            fighters_stamina - массив выносливости для каждого участника турнира,  length(fighters_stamina)=4, 0<=fighters_stamina[i]<=10
            Вывод:

            Integer[] - шанс победы каждого участника турнира, в процентах, округленных до целого числа (из-за округления может получиться, что сумма процентов не 100, это не страшно - мы все равно поймем кто лучший)
            Пример:

            fighters_stamina = [2, 1, 0, 2]
            GetResult(fighters_stamina) = [33, 33, 0, 33]

            Есть три варианта распределения бойцов в турнирной сетке:
            В первом варианте побеждает боец №4
            [2, 1] [0, 2]
                [1, 2]
                 [1]
            Во втором - второй боец №2 (при данном вариант турнирной сетки он третий)
            [2, 2] [1, 0]
               [0, 1]
                 [1]
            В третьем - боец №1
            [2, 0] [1, 2]
                [2, 1]
                  [1]

            У 1, 2 и 4 бойца есть равный шанс победить
         */
        public static List<int> GetResult(List<int> fightersStamina, int stage)
        {
            var fighters = fightersStamina
                .Select((s, i) => new Fighter { InitialStamina = s, CurrentStamina = s, Index = i})
                .ToArray();

            var tournamentStages = new List<TournamentStage> {new TournamentStage(fighters)};
            var nextTournamentStages = new List<TournamentStage>();
            var totalPossibleInitialTournamentStageVariants = tournamentStages[0].TournamentStageVariants.Count();

            while (1 < stage)
            {
                stage >>= 1;

                foreach (var tournamentStage in tournamentStages)
                {
                    tournamentStage.Run();

                    if (1 < stage)
                        nextTournamentStages.AddRange(tournamentStage.GetNextStages());
                }

                if(1 >= stage) break;
                
                tournamentStages = nextTournamentStages;
            }

            var results = Enumerable.Repeat(decimal.Zero, fightersStamina.Count).ToList();
            var calculationsData = new Dictionary<int, Dictionary<int, int>>();

            foreach (var tournamentStage in tournamentStages)
            {
                foreach (var tournamentStageVariant in tournamentStage.TournamentStageVariants)
                {
                    if (!calculationsData.ContainsKey(tournamentStageVariant.Token))
                    {
                        calculationsData.Add(tournamentStageVariant.Token, new Dictionary<int, int>());
                    }

                    foreach (var fight in tournamentStageVariant.Fights)
                    {
                        foreach (var winner in fight.Winners)
                        {
                            if (!calculationsData[tournamentStageVariant.Token].ContainsKey(winner.Index))
                            {
                                calculationsData[tournamentStageVariant.Token].Add(winner.Index, 1);
                            }
                            else
                            {
                                calculationsData[tournamentStageVariant.Token][winner.Index]++;
                            }
                        }
                    }
                }
            }

            foreach (var token in calculationsData.Keys)
            {
                var totalWins = calculationsData[token].Values.Sum();

                foreach (var fighterIndex in calculationsData[token].Keys)
                {
                    results[fighterIndex] += ((decimal) calculationsData[token][fighterIndex]) / totalWins;
                }
            }

            return results.Select(r => (int) Math.Round((r / totalPossibleInitialTournamentStageVariants) * 100)).ToList();
        }

        [DebuggerDisplay("Index = {Index}, InitialStamina = {InitialStamina}, CurrentStamina = {CurrentStamina}")]
        public struct Fighter
        {
            public int InitialStamina;

            public int CurrentStamina;

            public int Index { get; set; }

            public Fighter SetStamina(int stamina)
            {
                CurrentStamina = stamina;
                return this;
            }
        }

        [DebuggerDisplay("Fighter1 (Index = {_fighter1.Index}, Stamina = {_fighter1.CurrentStamina}, Fighter2 (Index = {_fighter2.Index}, Stamina = {_fighter2.CurrentStamina}")]
        public class Fight
        {
            private Fighter _fighter1;
            private Fighter _fighter2;

            public Fight(Fighter fighter1, Fighter fighter2)
            {
                _fighter1 = fighter1;
                _fighter2 = fighter2;
            }

            public Fighter Fighter1 => _fighter1;

            public Fighter Fighter2 => _fighter2;

            public List<Fighter> Winners { get; private set; }

            public void Run()
            {
                if(null == Winners)
                {
                    Winners = new List<Fighter>();
                }

                if (_fighter1.CurrentStamina == _fighter2.CurrentStamina)
                {
                    Winners.Add(_fighter1.SetStamina(0));
                    Winners.Add(_fighter2.SetStamina(0));
                }
                else if (_fighter1.CurrentStamina > _fighter2.CurrentStamina)
                {
                    Winners.Add(_fighter1.SetStamina(_fighter1.CurrentStamina - _fighter2.CurrentStamina));
                }
                else
                {
                    Winners.Add(_fighter2.SetStamina(_fighter2.CurrentStamina - _fighter1.CurrentStamina));
                }
            }
        }

        public class TournamentStage
        {
            public TournamentStage(params Fighter[] fighters) : this(null, fighters)
            {
            }

            public TournamentStage(int? token, params Fighter[] fighters)
            {
                TournamentStageVariants = GenerateStageFightSetVariants(token, fighters).ToList();
            }

            public IEnumerable<TournamentStageVariant> TournamentStageVariants { get; }

            public void Run() {
                
                foreach (var variant in TournamentStageVariants)
                {
                    variant.Run();
                }
            }

            private static IEnumerable<TournamentStageVariant> GenerateStageFightSetVariants(int? token, IReadOnlyList<Fighter> fighters)
            {
                var innerToken = 0;

                switch (fighters.Count)
                {
                    case 4:
                        yield return new TournamentStageVariant(
                            token ?? ++innerToken,
                            new Fight(fighters[0], fighters[1]), 
                            new Fight(fighters[2], fighters[3])
                        );

                        yield return new TournamentStageVariant(
                            token ?? ++innerToken,
                            new Fight(fighters[0], fighters[2]),
                            new Fight(fighters[1], fighters[3])
                        );

                        yield return new TournamentStageVariant(
                            token ?? ++innerToken,
                            new Fight(fighters[0], fighters[3]),
                            new Fight(fighters[1], fighters[2])
                        );
                        break;
                    default: // i.e. 2
                        yield return new TournamentStageVariant(
                            token ?? ++innerToken,
                            new Fight(fighters[0], fighters[1])
                        );
                        break;
                }
            }

            public IEnumerable<TournamentStage> GetNextStages()
            {
                var nextStages = new List<TournamentStage>();
                
                foreach (var tournamentStageVariant in TournamentStageVariants)
                {
                    nextStages.AddRange(tournamentStageVariant.GenerateNextStages());
                }

                return nextStages;
            }
        }

        public class TournamentStageVariant
        {
            private bool _completed;

            public int Token { get; }

            public TournamentStageVariant(int token, params Fight[] fights)
            {
                Token = token;
                Fights = fights.ToList();
            }

            public List<Fight> Fights { get; }

            public IEnumerable<TournamentStage> GenerateNextStages()
            {
                var fighterSetVariants = new List<FighterList> { new FighterList() };

                foreach (var fight in Fights)
                {
                    if (1 == fight.Winners.Count)
                    {
                        foreach (var fighterSetVariant in fighterSetVariants)
                        {
                            fighterSetVariant.Add(fight.Winners[0]); 
                        }
                    }
                    else
                    {
                        fighterSetVariants = (from winner in fight.Winners 
                                                          from fighterSetVariant in fighterSetVariants 
                                                          select new FighterList(fighterSetVariant, winner)).ToList();
                    }
                }

                return fighterSetVariants.Select(_ => new TournamentStage(Token, _.ToArray()));
            }

            public void Run()
            {
                if (_completed) return;

                foreach (var fight in Fights)
                {
                    fight.Run();
                }

                _completed = true;
            }
        }

        public class FighterList : List<Fighter>
        {
            public FighterList()
            {

            }

            public FighterList(IEnumerable<Fighter> fighters, Fighter newFighter)
            {
                AddRange(fighters);
                Add(newFighter);
            }
        }
    }
}
