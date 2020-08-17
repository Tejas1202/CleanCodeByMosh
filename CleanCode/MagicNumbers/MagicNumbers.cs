
namespace CleanCode.MagicNumbers
{
    public class MagicNumbers
    {
        #region Code Smell
        //public void ApproveDocument(int status)
        //{
        //    if (status == 1)
        //    {
        //        // ...
        //    }
        //    else if (status == 2)
        //    {
        //        // ...
        //    }
        //}

        //public void RejectDoument(string status)
        //{
        //    switch (status)
        //    {
        //        case "1":
        //            // ...
        //            break;
        //        case "2":
        //            // ...
        //            break;
        //    }
        //}
        #endregion

        #region Refactored Code
        public void ApprovedDocument(DocumentStatus status)
        {
            if (status == DocumentStatus.Draft)
            {
                //...
            }
            else if (status == DocumentStatus.Lodged)
            {
                //...
            }

        }

        public void RejectDocument(DocumentStatus status)
        {
            switch (status)
            {
                case DocumentStatus.Draft:
                    //..
                    break;
                case DocumentStatus.Lodged:
                    //..
                    break;
            }
        }
        #endregion
    }

    // Replacing Magic numbers by enum and passing enum as a parameter to avoid casting inside the method
    public enum DocumentStatus
    {
        Draft = 1,
        Lodged = 2
    }
}
