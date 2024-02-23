namespace HallodocMVC.Controllers
{
    public class Encyptdecypt
    {
        public string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }
        public string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }
        public  string EncryptDate(DateTime date)
        {
            Encyptdecypt data = new Encyptdecypt();
            string dateString = date.ToString("yyyy-MM-ddTHH:mm:ss");
            return data.EnryptString(dateString);
        }
        public  DateTime DecryptDate(string encryptedDate)
        {
            Encyptdecypt data=new Encyptdecypt();
            string decryptedString = data.DecryptString(encryptedDate);
            return DateTime.ParseExact(decryptedString, "yyyy-MM-ddTHH:mm:ss", null);
        }
    }
}