namespace FCamara_Test.Help
{
    public static class StringHelp
    {
        public static string RemoverMascara(this string valor)
        {
            if (string.IsNullOrEmpty(valor))
                return valor;

            return valor.Replace(".", "").Replace("-", "").Replace("/","");
        }
    }
}
