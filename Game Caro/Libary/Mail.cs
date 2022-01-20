using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Caro
{
    class Mail
    {
        public string user = "khoanguyen2181195@gmail.com";
        public string password = "lifeisagift55";

        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string File { get; set; }


        public Mail()
        {

        }

        public Mail(string fromEmail, string toEmail, string title, string content, string file)
        {
            FromEmail = fromEmail;
            ToEmail = toEmail;
            Title = title;
            Content = content;
            File = file;
        }
    }
}
