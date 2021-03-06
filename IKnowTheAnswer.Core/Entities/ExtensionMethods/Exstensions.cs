namespace IKnowTheAnswer.Core.ExtensionMethods
{
    public static class Exstensions
    {
        public static bool IsIdValid(this int id)
        {
            try
            {
                if (id == null)
                {
                    return false;
                }

                if (id <= 0)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsIdInvalid(this int id)
        { 
            try
            {
                if (id == null)
                {
                    return true;
                }

                if (id <= 0)
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}