namespace News365.Business.Contants;
public static class UrlSeoHelper
{
    public static string UrlSeo(string Metin)
    {
        if (Metin == null)
        {
            return string.Empty;
        }

        try
        {
            string strReturn = Metin.Trim();
            strReturn = strReturn.Replace("ğ", "g");
            strReturn = strReturn.Replace("Ğ", "G");
            strReturn = strReturn.Replace("ü", "u");
            strReturn = strReturn.Replace("Ü", "U");
            strReturn = strReturn.Replace("ş", "s");
            strReturn = strReturn.Replace("Ş", "S");
            strReturn = strReturn.Replace("ı", "i");
            strReturn = strReturn.Replace("İ", "I");
            strReturn = strReturn.Replace("ö", "o");
            strReturn = strReturn.Replace("Ö", "O");
            strReturn = strReturn.Replace("ç", "c");
            strReturn = strReturn.Replace("Ç", "C");
            strReturn = strReturn.Replace("-", "+");
            strReturn = strReturn.Replace(" ", "+");
            strReturn = strReturn.Replace("ə", "e");
            strReturn = strReturn.Trim();
            strReturn = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9+]").Replace(strReturn, "");
            strReturn = strReturn.Trim();
            strReturn = strReturn.Replace("+", "-");
            return strReturn;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public static string UppercaseWords(string value)
    {
        char[] array = value.ToCharArray();
        if (array.Length >= 1)
        {
            if (char.IsLower(array[0]))
            {
                array[0] = char.ToUpper(array[0]);
            }
        }
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i - 1] == ' ')
            {
                if (char.IsLower(array[i]))
                {
                    array[i] = char.ToUpper(array[i]);
                }
            }
        }
        return new string(array);
    }
}