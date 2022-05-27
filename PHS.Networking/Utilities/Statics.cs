namespace PHS.Networking.Utilities
{
    public static class Statics
    {
        public static byte[] ByteArrayAppend(byte[] first, byte[] second)
        {
            var array = new byte[first.Length + second.Length];
            first.CopyTo(array, 0);
            second.CopyTo(array, first.Length);
            return array;
        }
        public static bool ByteArrayContainsSequence(byte[] toSearch, byte[] toFind)
        {
            for (var i = 0; i + toFind.Length < toSearch.Length; i++)
            {
                var allSame = true;
                for (var j = 0; j < toFind.Length; j++)
                {
                    if (toSearch[i + j] != toFind[j])
                    {
                        allSame = false;
                        break;
                    }
                }

                if (allSame)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
