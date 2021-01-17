using System.Collections.Generic;
using Shotr.Core.Entities.Web;

namespace Shotr.Core.Model
{ 
    public class LoginResponse
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public List<UploadItem> Uploads { get; set; }
    }
}
