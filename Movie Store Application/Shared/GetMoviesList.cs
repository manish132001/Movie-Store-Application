using Movie_Store_Application.Models.Domain;
using Movie_Store_Application.Repositories.Abstraction;
using Movie_Store_Application.Repositories.Implementation;

namespace Movie_Store_Application.Shared
{
    public sealed class GetList
    {
        public string text;
        private GetList() 
        {
            GetData();
        }
        private static GetList _instance;
        public static GetList Instance()
        {
            if (_instance == null)
            {
                _instance =  new GetList();
            }
            return _instance;
        }
        private void  GetData()
        {
            text = "This Application is about Movies.";
            
            //return res;
        }
    }
}
