Solution solution = new();
Console.WriteLine(solution.NumWays(3, 2));
Console.WriteLine(solution.NumWays(2, 4));
Console.WriteLine(solution.NumWays(4, 2));
Console.WriteLine(solution.NumWays(438, 315977));

public class Solution
{
	private readonly int modulo = 1000000007;
	private int[][] dp;
	private int arrLen;
	private int DFS(int currentLen, int remain)
	{
		if (remain == 0)
		{
			return currentLen == 0 ? 1 : 0;
		}

		if (dp[currentLen][remain] != -1)
		{
			return dp[currentLen][remain];
		}
		int ways = DFS(currentLen, remain - 1) % modulo;
		if (currentLen > 0)
		{
			ways = (ways + DFS(currentLen - 1, remain - 1)) % modulo;
		}
		if (currentLen < arrLen - 1)
		{
			ways = (ways + DFS(currentLen + 1, remain - 1)) % modulo;
		}
		dp[currentLen][remain] = ways;
		return dp[currentLen][remain];
	}

	public int NumWays(int steps, int arrLen)
	{
		arrLen = Math.Min(arrLen, steps);
		dp = new int[arrLen][];
		this.arrLen = arrLen;
		for (int i = 0; i < arrLen; ++i)
		{
			dp[i] = new int[steps + 1];
			Array.Fill(dp[i], -1);
		}
		return DFS(0, steps);
	}
}