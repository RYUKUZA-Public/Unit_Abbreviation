public class UnitAbbreviation
{
    public static string NumAbb(long originNum)
    {
        // 記号(symbol)一覧
        string[] symbol = new string[7] { "K", "M", "G", "T", "P", "E", "Z" };
        // 受信した数字を文字列に変更
        string result = originNum.ToString();

        // 数字 + symbolは最大4桁まで, 数字が4桁以下なら、Symbolなしでそのまま出力
        if (result.Length < 4)
            return result;

        for (int i = 0; i < symbol.Length; i++)
        {
            // 文字列の長崎チェック
            if (4 + 3 * i <= result.Length && result.Length == 4 + 3 * (i + 1))
            {
                // 3の余りの値(n)は、[0, 1, 2]
                int n = result.Length % 3;
                // 残りの値(n)が、0なら、3で
                n = n == 0 ? 3 : n;
                
                // 残り値個数 (n) = 前桁個数
                // 前桁の表現に使用した値の、すぐ後ろの値を小数点以下の数字料表現
                result = $"{result.Substring(0, n)}.{result.Substring(n, 1)}";
                result += symbol[i];
                break;
            }
        }
        return result;
    }
}
