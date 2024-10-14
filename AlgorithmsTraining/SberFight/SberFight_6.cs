using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsTraining.SberFight
{
    public class SberFight_6
    {
        /*
         * Вам даётся массив имён трёх братьев и массив утверждений, которые являются правдивыми. Список возможных утверждений:

        "is youngest" – самый младший
        "is not youngest" – не самый младший
        "is not oldest" – не самый старший
        "is oldest" – самый старший
        Вам предстоит расставить всех братьев по возрастанию возраста
         Ввод: 

        names – массив имён трёх братьев, length(names)=3
        statements – массив(string[]), statements[i] = ["a-b"], где a – имя брата, b – утверждение, их разделяет тире без пробелов. Для одного брата может быть несколько утверждений
         Вывод:  

        String[] – список братьев от самого младшего до самого старшего, решение всегда есть и всегда одно
        Example:

        names=["Kevin", "Jack", "Mark"]
        statements=["Kevin-is not youngest", "Jack-is oldest", "Mark-is not oldest"]
        GetResult(names, statements)=["Mark", "Kevin", "Jack"]

        Example:

        [is youngest]   [is not youngest, is not oldest]  [is oldest]
        [is not oldest]   [is not youngest]  [is oldest]
        [is youngest]   [is not oldest]   [is not youngest]
         */
        public static List<string> GetResult(List<string> names, List<string> statements)
        {
            var brothers = ParseBrothers(names, statements);
            var brothersWithDefinedPositions = new List<Brother>();

            while(3 > brothersWithDefinedPositions.Count)
            {
                StartCycle:

                for (var i = 0; i < brothers.Count; i++)
                {
                    if (brothers[i].DefinedPosition.HasValue)
                    {
                        brothersWithDefinedPositions.Add(brothers[i]);
                        brothers.RemoveAt(i);
                        goto StartCycle;
                    }

                    foreach (var definedBrother in brothersWithDefinedPositions)
                    {
                        brothers[i].PossiblePositionMask = ~(~brothers[i].PossiblePositionMask | definedBrother.PossiblePositionMask);
                    }
                }
            }

            brothersWithDefinedPositions.Sort((b1, b2) => b1.DefinedPosition.Value.CompareTo(b2.DefinedPosition.Value));
            return brothersWithDefinedPositions.Select(_ => _.Name).ToList();
        }

        private static List<Brother> ParseBrothers(List<string> names, List<string> statements)
        {
            var brothers = new List<Brother>();

            var statementsDictionary = names.ToDictionary(name => name, _ => new List<string>());

            statements.ForEach(s =>
            {
                var parts = s.Split('-');
                statementsDictionary[parts[0]].Add(parts[1]);
            });

            foreach(var brotherName in statementsDictionary.Keys)
            {
                brothers.Add(new Brother { Name = brotherName, PossiblePositionMask = GetBrotherPositionMask(statementsDictionary[brotherName]) });
            }

            return brothers;
        }

        private static int GetBrotherPositionMask(List<string> statements)
        {
            var mask = 7;

            foreach(var s in statements)
            {
                switch (s)
                {
                    case "is youngest":
                        return 1;
                    case "is oldest":
                        return 4;
                    case "is not youngest":
                        mask ^= 1;
                        break;
                    case "is not oldest":
                        mask ^= 4;
                        break;
                }
            }

            return mask;
        }

        public class Brother
        {
            public string Name;

            public int PossiblePositionMask;

            public int? DefinedPosition
            {
                get
                {
                    switch (PossiblePositionMask)
                    {
                        case 1:
                            return 0;
                        case 2:
                            return 1;
                        case 4:
                            return 2;
                        default:
                            return null;
                    }
                }
            }
        }
    }
}
