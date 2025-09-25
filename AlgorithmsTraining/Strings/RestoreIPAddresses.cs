namespace AlgorithmsTraining.Strings;

public static class RestoreIPAddresses
{
    /*
     * 93. Restore IP Addresses

       A valid IP address consists of exactly four integers separated by single dots. Each integer is between 0 and 255 
       (inclusive) and cannot have leading zeros.

       For example, "0.1.2.201" and "192.168.1.1" are valid IP addresses, but "0.011.255.245", "192.168.1.312" and 
       "192.168@1.1" are invalid IP addresses.

       Given a string s containing only digits, return all possible valid IP addresses that can be formed by inserting 
       dots into s. You are not allowed to reorder or remove any digits in s. You may return the valid IP addresses in any order.

       Example 1:
       
       Input: s = "25525511135"
       Output: ["255.255.11.135","255.255.111.35"]
       
       Example 2:
       
       Input: s = "0000"
       Output: ["0.0.0.0"]
       
       Example 3:
       
       Input: s = "101023"
       Output: ["1.0.10.23","1.0.102.3","10.1.0.23","10.10.2.3","101.0.2.3"]

       Constraints:

        [1] 1 <= s.length <= 20
        [2] s consists of digits only.

        Runtime
        2 ms
        Beats 90.05%

        Memory
        47.98 MB
        Beats 82.81%
     */
    public static IList<string> Solution(string s) => Descent(s.AsMemory(), 0, new ReadOnlyMemory<char>[4], []);

    private static IList<string> Descent(ReadOnlyMemory<char> s, int octetNumber, ReadOnlyMemory<char>[] octets, IList<string> results)
    {
        switch(octetNumber)
        {
            case 3:
                if (1 == s.Length) { octets[octetNumber] = s[..1]; results.Add(GenerateIP(octets)); }
                if (2 == s.Length && IsValidOctet(s.Span[0], s.Span[1])) { octets[octetNumber] = s[..2]; results.Add(GenerateIP(octets)); }
                if (3 == s.Length && IsValidOctet(s.Span[0], s.Span[1], s.Span[2])) { octets[octetNumber] = s[..3]; results.Add(GenerateIP(octets)); }
                break;
            default:
                if (s.Length >= 1 && IsValidOctet(s.Span[0])) 
                { octets[octetNumber] = s[..1]; Descent(s[1..], octetNumber + 1, octets, results); }

                if (s.Length >= 2 && IsValidOctet(s.Span[0], s.Span[1])) 
                { octets[octetNumber] = s[..2]; Descent(s[2..], octetNumber + 1, octets, results); }

                if (s.Length >= 3 && IsValidOctet(s.Span[0], s.Span[1], s.Span[2])) 
                { octets[octetNumber] = s[..3]; Descent(s[3..], octetNumber + 1, octets, results); }

                break;
        }

        return results;
    }

    private static bool IsValidOctet(params char[] chars)
        => ('0' == chars[0])
            ? 1 == chars.Length
            : chars.Length switch
            {
                3 => ((chars[0] - '0') * 100 + (chars[1] - '0') * 10 + (chars[2] - '0')) <= 255,
                _ => true
            };

    private static string GenerateIP(ReadOnlyMemory<char>[] octets) => $"{octets[0]}.{octets[1]}.{octets[2]}.{octets[3]}";
}
