using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace FF14_Lodestone_Job_Trust_System
{
    public class HTML
    {
        public static string HTML_Catch(string URL)
        {
            string return_string;

            //HTTP通信に必要なクラスを定義します
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);
            HttpWebResponse res = null;
            HttpStatusCode statusCode;
            try
            {
                //レスポンスを確認します
                res = (HttpWebResponse)req.GetResponse();
                statusCode = res.StatusCode;
                //HTMLを取得します
                var resSt = res.GetResponseStream();
                var sr = new StreamReader(resSt, Encoding.UTF8);
                return_string = sr.ReadToEnd();
                return return_string;

            }
            catch (WebException ex)
            {
                //エラーの種別を確認します
                res = (HttpWebResponse)ex.Response;
                if (res != null)
                {
                    //エラーメッセージを表示します
                    MessageBox.Show("アクセス中にエラーが発生しました。\n" +
                                                    "以下の項目を確認してください。\n" +
                                                    "\n" +
                                                    "1. アドレス(キャラクターID)が間違えていないか\n" +
                                                    "2. サーバーがメンテナンス中などではないか", 
                                                    "HTTP ERROR", 
                                                    MessageBoxButtons.OK, 
                                                    MessageBoxIcon.Error);
                    statusCode = res.StatusCode;
                    int code = (int)statusCode;
                    return_string = "ERROR";
                    return return_string;
                }
                else
                {
                    throw; // サーバ接続不可などの場合は再スロー
                }
            }
            finally
            {
                if (res != null)
                {
                    res.Close();
                }
            }
        }
    }
}
