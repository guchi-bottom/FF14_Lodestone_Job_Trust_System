using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF14_Lodestone_Job_Trust_System
{
    public partial class Form1 : Form
    {
        //デバッグ用コンソールの定義
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
        //Lodestone URL特定情報
        public string Lodestone_Chara_ID = "";

        //HTMLからの文字列抽出情報
        List<string> Job_level = new();
        List<string> Job_name = new();
        List<string> Job_exp = new();

        //ジョブ短縮形管理用配列
        string[] Job_shortening = { "PLD", "WAR", "DRK", "GNB", "WHM", "SCH", "AST", "MNK", "DRG", "NIN", "SAM", "BRD", "MCN", "DNC", "BLM", "SMN", "RDM", "BLU", "CRP", "BSM", "ARM", "GSM", "LTW", "WVR", "ALC", "CUL", "MIN", "BTN", "FSH" };

        //各ジョブ管理用List
        public List<List<string>> Class_Job = new();
        public List<string> PLD = new();
        public List<string> WAR = new();
        public List<string> DRK = new();
        public List<string> GNB = new();
        public List<string> WHM = new();
        public List<string> SCH = new();
        public List<string> AST = new();
        public List<string> MNK = new();
        public List<string> DRG = new();
        public List<string> NIN = new();
        public List<string> SAM = new();
        public List<string> BRD = new();
        public List<string> MCN = new();
        public List<string> DNC = new();
        public List<string> BLM = new();
        public List<string> SMN = new();
        public List<string> RDM = new();
        public List<string> BLU = new();
        public List<string> CRP = new();
        public List<string> BSM = new();
        public List<string> ARM = new();
        public List<string> GSM = new();
        public List<string> LTW = new();
        public List<string> WVR = new();
        public List<string> ALC = new();
        public List<string> CUL = new();
        public List<string> MIN = new();
        public List<string> BTN = new();
        public List<string> FSH = new();

        //コンポーネント管理用List
        List<List<Label>> Class_Job_Label = new();
        List<Label> PLD_Label = new();
        List<Label> WAR_Label = new();
        List<Label> DRK_Label = new();
        List<Label> GNB_Label = new();
        List<Label> WHM_Label = new();
        List<Label> SCH_Label = new();
        List<Label> AST_Label = new();
        List<Label> MNK_Label = new();
        List<Label> DRG_Label = new();
        List<Label> NIN_Label = new();
        List<Label> SAM_Label = new();
        List<Label> BRD_Label = new();
        List<Label> MCN_Label = new();
        List<Label> DNC_Label = new();
        List<Label> BLM_Label = new();
        List<Label> SMN_Label = new();
        List<Label> RDM_Label = new();
        List<Label> BLU_Label = new();
        List<Label> CRP_Label = new();
        List<Label> BSM_Label = new();
        List<Label> ARM_Label = new();
        List<Label> GSM_Label = new();
        List<Label> LTW_Label = new();
        List<Label> WVR_Label = new();
        List<Label> ALC_Label = new();
        List<Label> CUL_Label = new();
        List<Label> MIN_Label = new();
        List<Label> BTN_Label = new();
        List<Label> FSH_Label = new();

        List<Panel> Job_Group = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //プロパティ保存情報をキャッチします
            Lodestone_Chara_ID = Properties.Settings.Default.Chara_ID;
            textBox1.Text = Lodestone_Chara_ID;

            //Labelコントロールの設定を行います
            L_Tank.ForeColor = Color.FromArgb(0x46, 0x5D, 0xCB);
            L_Healer.ForeColor = Color.FromArgb(0x48, 0x7B, 0x39);
            L_Melee.ForeColor = Color.FromArgb(0x7F, 0x3A, 0x3B);
            L_Physical.ForeColor = Color.FromArgb(0x7F, 0x3A, 0x3B);
            L_Magical.ForeColor = Color.FromArgb(0x7F, 0x3A, 0x3B);
            L_Crafter.ForeColor = Color.FromArgb(0x6D, 0x4D, 0xB7);
            L_Gatherer.ForeColor = Color.FromArgb(0xB8, 0x9A, 0x40);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TextBoxの文字列を取得します
            Lodestone_Chara_ID = textBox1.Text;
            DialogResult result = MessageBox.Show("取得したいキャラクターのIDは\"" + Lodestone_Chara_ID + "\"ですか?",
                "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                //プロパティに情報を保存します
                Properties.Settings.Default.Chara_ID = Lodestone_Chara_ID;
                Properties.Settings.Default.Save();

                //初期化を行います
                Initializing();

                //Labelコンポーネントの設定を行います
                html_status.Visible = true;         // 可視化
                html_status.Text = "取得中";       // 「取得中」の文字列を表示することで処理中であることを明記します。
                html_status.Update();               // 表示を更新します。

                //取得URLの設定を行います
                string url = "https://jp.finalfantasyxiv.com/lodestone/character/" + Lodestone_Chara_ID + "/class_job/";

                //HTMLソースコードの取得を行います
                HTML html = new();
                string lodestome_html = HTML.HTML_Catch(url);
                //HTTP STASUS(4XX, 5XX)などの動作を除去します
                if (lodestome_html != "ERROR")
                {
                    html_status.Text = "処理中";

                    //下処理を開始します
                    lodestome_html = lodestome_html.Replace("	", "");
                    lodestome_html = lodestome_html.Replace("\n", "\r\n");

                    //空白行の除去を行います
                    for (; ; )
                    {
                        if (lodestome_html.Contains("\r\n\r\n"))
                            lodestome_html = lodestome_html.Replace("\r\n\r\n", "\r\n");
                        else
                            break;
                    }

                    //タグ内改行の諸居を行います
                    for (; ; )
                    {
                        if (lodestome_html.Contains("\"\r\n"))
                            lodestome_html = lodestome_html.Replace("\"\r\n", "\"");
                        else
                            break;
                    }

                    //検索を開始します。
                    int start_index = 0;
                    int end_index = 0;
                    string extraction = "";

                    //クラス・ジョブのレベルを取得します(2種類のタグに対応)
                    for (; ; )
                    {
                        if (0 < lodestome_html.IndexOf("<div class=\"character__job__level\">", start_index))
                        {
                            start_index = lodestome_html.IndexOf("<div class=\"character__job__level\">", start_index);
                            end_index = lodestome_html.IndexOf("</div>", start_index);
                            extraction = lodestome_html[start_index..end_index];
                            Job_level.Add(extraction);
                            start_index = end_index;
                        }
                        else break;
                    }
                    List<int> indexs = new();
                    start_index = 0;
                    for (; ; )
                    {
                        if (2 < lodestome_html.IndexOf("<div class=\"character__job__name js__tooltip\"", start_index))
                        {

                            start_index = lodestome_html.IndexOf("<div class=\"character__job__name js__tooltip\"", start_index);
                            end_index = lodestome_html.IndexOf("</div>", start_index);
                            extraction = lodestome_html[start_index..end_index];
                            Job_name.Add(extraction);
                            indexs.Add(start_index);
                            start_index = end_index;
                        }
                        else break;
                    }

                    //クラス・ジョブ名を取得します
                    start_index = 0;
                    for (; ; )
                    {
                        if (2 < lodestome_html.IndexOf("<div class=\"character__job__name character__job__name--meister js__tooltip\"", start_index))
                        {
                            start_index = lodestome_html.IndexOf("<div class=\"character__job__name character__job__name--meister js__tooltip\"", start_index);
                            end_index = lodestome_html.IndexOf("</div>", start_index);
                            extraction = lodestome_html[start_index..end_index];
                            Job_name.Add(extraction);
                            indexs.Add(start_index);
                            start_index = end_index;
                        }
                        else break;
                    }
                    start_index = 0;
                    for (; ; )
                    {
                        if (0 < lodestome_html.IndexOf("<div class=\"character__job__name\"", start_index))
                        {
                            start_index = lodestome_html.IndexOf("<div class=\"character__job__name\"", start_index);
                            end_index = lodestome_html.IndexOf("</div>", start_index);
                            extraction = lodestome_html[start_index..end_index];
                            Job_name.Add(extraction);
                            indexs.Add(start_index);
                            start_index = end_index;
                        }
                        else break;
                    }

                    //取得した情報を並び変えることでクラス・ジョブの順番を修正します
                    for (int i = 0; i < indexs.Count - 1; i++)
                    {
                        if (indexs[i] > indexs[i + 1])
                        {
                            int temp = indexs[i];
                            indexs[i] = indexs[i + 1];
                            indexs[i + 1] = temp;

                            string Temp = Job_name[i];
                            Job_name[i] = Job_name[i + 1];
                            Job_name[i + 1] = Temp;

                            i = -1;
                        }
                    }

                    //ジョブ経験値を取得します
                    start_index = 0;
                    for (; ; )
                    {
                        if (2 < lodestome_html.IndexOf("<div class=\"character__job__exp\">", start_index))
                        {
                            start_index = lodestome_html.IndexOf("<div class=\"character__job__exp\">", start_index);
                            end_index = lodestome_html.IndexOf("</div>", start_index);
                            extraction = lodestome_html[start_index..end_index];
                            Job_exp.Add(extraction);
                            start_index = end_index;
                        }
                        else break;
                    }

                    //抽出した文字列から存在する余計な文字列を除去します
                    for (int i = 0; i < Job_level.Count; i++)
                        Job_level[i] = Job_level[i][(Job_level[i].LastIndexOf(">") + 1)..];

                    for (int i = 0; i < Job_name.Count; i++)
                        Job_name[i] = Job_name[i][(Job_name[i].LastIndexOf(">") + 1)..];

                    for (int i = 0; i < Job_exp.Count; i++)
                        Job_exp[i] = Job_exp[i][(Job_exp[i].LastIndexOf(">") + 1)..];

                    for (int i = 0; i < Job_exp.Count; i++)
                        Job_exp[i] = Job_exp[i].Replace(",", "");

                    //取得した情報をジョブ毎のListに格納していきます
                    int counting = 0;  //保存したListのインデックスを保存します
                    foreach (string Name in Job_name)
                    {
                        if (Name == "剣術士" || Name == "ナイト")
                        {
                            if (Name == "剣術士") PLD.Add("クラス");
                            else PLD.Add("ジョブ");
                            PLD.Add(Job_name[counting]);
                            PLD.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            PLD.Add(neko[0]);
                            PLD.Add(neko[1]);
                        }
                        if (Name == "斧術士" || Name == "戦士")
                        {
                            if (Name == "斧術士") WAR.Add("クラス");
                            else WAR.Add("ジョブ");
                            WAR.Add(Job_name[counting]);
                            WAR.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            WAR.Add(neko[0]);
                            WAR.Add(neko[1]);
                        }
                        if (Name == "暗黒騎士")
                        {
                            DRK.Add("ジョブ");
                            DRK.Add(Job_name[counting]);
                            DRK.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            DRK.Add(neko[0]);
                            DRK.Add(neko[1]);
                        }
                        if (Name == "ガンブレイカー")
                        {
                            GNB.Add("ジョブ");
                            GNB.Add(Job_name[counting]);
                            GNB.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            GNB.Add(neko[0]);
                            GNB.Add(neko[1]);
                        }
                        if (Name == "幻術士" || Name == "白魔道士")
                        {
                            if (Name == "幻術士") WHM.Add("クラス");
                            else WHM.Add("ジョブ");
                            WHM.Add(Job_name[counting]);
                            WHM.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            WHM.Add(neko[0]);
                            WHM.Add(neko[1]);
                        }
                        if (Name == "学者")
                        {
                            SCH.Add("ジョブ");
                            SCH.Add(Job_name[counting]);
                            SCH.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            SCH.Add(neko[0]);
                            SCH.Add(neko[1]);
                        }
                        if (Name == "占星術師")
                        {
                            AST.Add("ジョブ");
                            AST.Add(Job_name[counting]);
                            AST.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            AST.Add(neko[0]);
                            AST.Add(neko[1]);
                        }
                        if (Name == "格闘士" || Name == "モンク")
                        {
                            if (Name == "格闘士") MNK.Add("クラス");
                            else MNK.Add("ジョブ");
                            MNK.Add(Job_name[counting]);
                            MNK.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            MNK.Add(neko[0]);
                            MNK.Add(neko[1]);
                        }
                        if (Name == "槍術士" || Name == "竜騎士")
                        {
                            if (Name == "槍術士") DRG.Add("クラス");
                            else DRG.Add("ジョブ");
                            DRG.Add(Job_name[counting]);
                            DRG.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            DRG.Add(neko[0]);
                            DRG.Add(neko[1]);
                        }
                        if (Name == "双剣士" || Name == "忍者")
                        {
                            if (Name == "双剣士") NIN.Add("クラス");
                            else NIN.Add("ジョブ");
                            NIN.Add(Job_name[counting]);
                            NIN.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            NIN.Add(neko[0]);
                            NIN.Add(neko[1]);
                        }
                        if (Name == "侍")
                        {
                            SAM.Add("ジョブ");
                            SAM.Add(Job_name[counting]);
                            SAM.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            SAM.Add(neko[0]);
                            SAM.Add(neko[1]);
                        }
                        if (Name == "弓術士" || Name == "吟遊詩人")
                        {
                            if (Name == "弓術士") BRD.Add("クラス");
                            else BRD.Add("ジョブ");
                            BRD.Add(Job_name[counting]);
                            BRD.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            BRD.Add(neko[0]);
                            BRD.Add(neko[1]);
                        }
                        if (Name == "機工士")
                        {
                            MCN.Add("ジョブ");
                            MCN.Add(Job_name[counting]);
                            MCN.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            MCN.Add(neko[0]);
                            MCN.Add(neko[1]);
                        }
                        if (Name == "踊り子")
                        {
                            DNC.Add("ジョブ");
                            DNC.Add(Job_name[counting]);
                            DNC.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            DNC.Add(neko[0]);
                            DNC.Add(neko[1]);
                        }
                        if (Name == "呪術士" || Name == "黒魔道士")
                        {
                            if (Name == "呪術士") BLM.Add("クラス");
                            else BLM.Add("ジョブ");
                            BLM.Add(Job_name[counting]);
                            BLM.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            BLM.Add(neko[0]);
                            BLM.Add(neko[1]);
                        }
                        if (Name == "巴術士" || Name == "召喚士")
                        {
                            if (Name == "巴術士") SMN.Add("クラス");
                            else SMN.Add("ジョブ");
                            SMN.Add(Job_name[counting]);
                            SMN.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            SMN.Add(neko[0]);
                            SMN.Add(neko[1]);
                        }
                        if (Name == "赤魔道士")
                        {
                            RDM.Add("ジョブ");
                            RDM.Add(Job_name[counting]);
                            RDM.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            RDM.Add(neko[0]);
                            RDM.Add(neko[1]);
                        }
                        if (Name == "青魔道士")
                        {
                            BLU.Add("ジョブ");
                            BLU.Add(Job_name[counting]);
                            BLU.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            BLU.Add(neko[0]);
                            BLU.Add(neko[1]);
                        }
                        if (Name == "木工師")
                        {
                            CRP.Add("クラス");
                            CRP.Add(Job_name[counting]);
                            CRP.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            CRP.Add(neko[0]);
                            CRP.Add(neko[1]);
                        }
                        if (Name == "鍛冶師")
                        {
                            BSM.Add("クラス");
                            BSM.Add(Job_name[counting]);
                            BSM.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            BSM.Add(neko[0]);
                            BSM.Add(neko[1]);
                        }
                        if (Name == "甲冑師")
                        {
                            ARM.Add("クラス");
                            ARM.Add(Job_name[counting]);
                            ARM.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            ARM.Add(neko[0]);
                            ARM.Add(neko[1]);
                        }
                        if (Name == "彫金師")
                        {
                            GSM.Add("クラス");
                            GSM.Add(Job_name[counting]);
                            GSM.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            GSM.Add(neko[0]);
                            GSM.Add(neko[1]);
                        }
                        if (Name == "革細工師")
                        {
                            LTW.Add("クラス");
                            LTW.Add(Job_name[counting]);
                            LTW.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            LTW.Add(neko[0]);
                            LTW.Add(neko[1]);
                        }
                        if (Name == "裁縫師")
                        {
                            WVR.Add("クラス");
                            WVR.Add(Job_name[counting]);
                            WVR.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            WVR.Add(neko[0]);
                            WVR.Add(neko[1]);
                        }
                        if (Name == "錬金術師")
                        {
                            ALC.Add("クラス");
                            ALC.Add(Job_name[counting]);
                            ALC.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            ALC.Add(neko[0]);
                            ALC.Add(neko[1]);
                        }
                        if (Name == "調理師")
                        {
                            CUL.Add("クラス");
                            CUL.Add(Job_name[counting]);
                            CUL.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            CUL.Add(neko[0]);
                            CUL.Add(neko[1]);
                        }
                        if (Name == "採掘師")
                        {
                            MIN.Add("クラス");
                            MIN.Add(Job_name[counting]);
                            MIN.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            MIN.Add(neko[0]);
                            MIN.Add(neko[1]);
                        }
                        if (Name == "園芸師")
                        {
                            BTN.Add("クラス");
                            BTN.Add(Job_name[counting]);
                            BTN.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            BTN.Add(neko[0]);
                            BTN.Add(neko[1]);
                        }
                        if (Name == "漁師")
                        {
                            FSH.Add("クラス");
                            FSH.Add(Job_name[counting]);
                            FSH.Add(Job_level[counting]);
                            string[] neko = Job_exp[counting].Split(" / ");
                            FSH.Add(neko[0]);
                            FSH.Add(neko[1]);
                        }
                        counting++;
                    }

                    //一元管理用Listに格納しアクセスを簡単にします
                    Class_Job.Add(PLD);
                    Class_Job.Add(WAR);
                    Class_Job.Add(DRK);
                    Class_Job.Add(GNB);
                    Class_Job.Add(WHM);
                    Class_Job.Add(SCH);
                    Class_Job.Add(AST);
                    Class_Job.Add(MNK);
                    Class_Job.Add(DRG);
                    Class_Job.Add(NIN);
                    Class_Job.Add(SAM);
                    Class_Job.Add(BRD);
                    Class_Job.Add(MCN);
                    Class_Job.Add(DNC);
                    Class_Job.Add(BLM);
                    Class_Job.Add(SMN);
                    Class_Job.Add(RDM);
                    Class_Job.Add(BLU);
                    Class_Job.Add(CRP);
                    Class_Job.Add(BSM);
                    Class_Job.Add(ARM);
                    Class_Job.Add(GSM);
                    Class_Job.Add(LTW);
                    Class_Job.Add(WVR);
                    Class_Job.Add(ALC);
                    Class_Job.Add(CUL);
                    Class_Job.Add(MIN);
                    Class_Job.Add(BTN);
                    Class_Job.Add(FSH);

                    html_status.Text = "表示中";

                    //表示を行います
                    //各コンポーネントのListを作成し、アクセスを簡単にするようにしておきます(泥沼戦法)
                    //Designerで編集後、ここで表示を行います
                    //Labelコンポーネントは非表示にしておき、処理開始後にVisible = trueに切り替えます
                    Visibled_Control();

                    //表示が終了した為ステータスを表示していたLabelコンポーネントを非表示にします
                    html_status.Visible = false;
                }
                else
                    html_status.Visible = false;
            }
        }

        public void Visibled_Control()
        {
            //配置座標用変数を定義します
            int Y = 19;

            //コントロール管理用Listにコントロールを格納します。
            Job_Group.Add(Tank);
            Job_Group.Add(Healer);
            Job_Group.Add(Melee);
            Job_Group.Add(Physical);
            Job_Group.Add(Magical);
            Job_Group.Add(Crafter);
            Job_Group.Add(Gatherer);

            Class_Job_Label.Add(PLD_Label);
            Class_Job_Label.Add(WAR_Label);
            Class_Job_Label.Add(DRK_Label);
            Class_Job_Label.Add(GNB_Label);
            Class_Job_Label.Add(WHM_Label);
            Class_Job_Label.Add(SCH_Label);
            Class_Job_Label.Add(AST_Label);
            Class_Job_Label.Add(MNK_Label);
            Class_Job_Label.Add(DRG_Label);
            Class_Job_Label.Add(NIN_Label);
            Class_Job_Label.Add(SAM_Label);
            Class_Job_Label.Add(BRD_Label);
            Class_Job_Label.Add(MCN_Label);
            Class_Job_Label.Add(DNC_Label);
            Class_Job_Label.Add(BLM_Label);
            Class_Job_Label.Add(SMN_Label);
            Class_Job_Label.Add(RDM_Label);
            Class_Job_Label.Add(BLU_Label);
            Class_Job_Label.Add(CRP_Label);
            Class_Job_Label.Add(BSM_Label);
            Class_Job_Label.Add(ARM_Label);
            Class_Job_Label.Add(GSM_Label);
            Class_Job_Label.Add(LTW_Label);
            Class_Job_Label.Add(WVR_Label);
            Class_Job_Label.Add(ALC_Label);
            Class_Job_Label.Add(CUL_Label);
            Class_Job_Label.Add(MIN_Label);
            Class_Job_Label.Add(BTN_Label);
            Class_Job_Label.Add(FSH_Label);

            //Labelコントロールを定義・作成します
            //Tank
            for (int i = 0; i < 4; i++)
            {
                Create_Name(Job_shortening[i], Y, i);
                Y += 19;
                Create_Lv(Job_shortening[i], Y, i);
                Y += 19;
                Create_Trust_ID(Job_shortening[i], Y, i);
                Y += 19;
                Create_Trust_Loop(Job_shortening[i], Y, i);
                Y += 19 * 2;
            }
            Y = 19;

            //Healer
            for (int i = 4; i < 7; i++)
            {
                Create_Name(Job_shortening[i], Y, i);
                Y += 19;
                Create_Lv(Job_shortening[i], Y, i);
                Y += 19;
                Create_Trust_ID(Job_shortening[i], Y, i);
                Y += 19;
                Create_Trust_Loop(Job_shortening[i], Y, i);
                Y += 19 * 2;
            }
            Y = 19;

            //Melee DPS
            for (int i = 7; i < 11; i++)
            {
                Create_Name(Job_shortening[i], Y, i);
                Y += 19;
                Create_Lv(Job_shortening[i], Y, i);
                Y += 19;
                Create_Trust_ID(Job_shortening[i], Y, i);
                Y += 19;
                Create_Trust_Loop(Job_shortening[i], Y, i);
                Y += 19 * 2;
            }
            Y = 19;

            //Physical Rannged DPS
            for (int i = 11; i < 14; i++)
            {
                Create_Name(Job_shortening[i], Y, i);
                Y += 19;
                Create_Lv(Job_shortening[i], Y, i);
                Y += 19;
                Create_Trust_ID(Job_shortening[i], Y, i);
                Y += 19;
                Create_Trust_Loop(Job_shortening[i], Y, i);
                Y += 19 * 2;
            }
            Y = 19;

            //Magical Rannged DPS
            for (int i = 14; i < 18; i++)
            {
                Create_Name(Job_shortening[i], Y, i);
                Y += 19;
                Create_Lv(Job_shortening[i], Y, i);
                Y += 19;
                if (i != 17)
                {
                    Create_Trust_ID(Job_shortening[i], Y, i);
                    Y += 19;
                    Create_Trust_Loop(Job_shortening[i], Y, i);
                    Y += 19 * 2;
                }
            }
            Y = 19;

            //Cracter
            for (int i = 18; i < 26; i++)
            {
                Create_Name(Job_shortening[i], Y, i);
                Y += 19;
                Create_Lv(Job_shortening[i], Y, i);
                Y += 19 * 2;
            }
            Y = 19;

            //Gatherer
            for (int i = 26; i < 29; i++)
            {
                Create_Name(Job_shortening[i], Y, i);
                Y += 19;
                Create_Lv(Job_shortening[i], Y, i);
                Y += 19 * 2;
            }

            //格納完了したコンポーネントを表示します
            //Tank
            for (int i = 0; i < 4; i++)
            {
                foreach (Label label in Class_Job_Label[i])
                    Job_Group[0].Controls.Add(label);
            }

            //Healer
            for (int i = 4; i < 7; i++)
            {
                foreach (Label label in Class_Job_Label[i])
                    Job_Group[1].Controls.Add(label);
            }

            //Melee DPS
            for (int i = 7; i < 11; i++)
            {
                foreach (Label label in Class_Job_Label[i])
                    Job_Group[2].Controls.Add(label);
            }

            //Physical Rannged DPS
            for (int i = 11; i < 14; i++)
            {
                foreach (Label label in Class_Job_Label[i])
                    Job_Group[3].Controls.Add(label);
            }

            //Magical Rannged DPS
            for (int i = 14; i < 18; i++)
            {
                foreach (Label label in Class_Job_Label[i])
                    Job_Group[4].Controls.Add(label);
            }

            //Cracter
            for (int i = 18; i < 26; i++)
            {
                foreach (Label label in Class_Job_Label[i])
                    Job_Group[5].Controls.Add(label);
            }

            //Gatherer
            for (int i = 26; i < 29; i++)
            {
                foreach (Label label in Class_Job_Label[i])
                    Job_Group[6].Controls.Add(label);
            }
        }

        private void Create_Name(string Job, int Y, int Index)
        {
            //文字列を取得するListをピックアップします
            List<string> neko = Class_Job[Index];
            //設定を行います
            Label lb = new()
            {
                Name = Job + "_Name",
                Text = neko[0] + "名: " + neko[1],
                Location = new Point(15, Y),
                AutoSize = true
            };
            //管理用Listに追加します
            Class_Job_Label[Index].Add(lb);
        }

        private void Create_Lv(string Job, int Y, int Index)
        {
            //文字列を取得するListをピックアップします
            List<string> neko = Class_Job[Index];

            //経験値のパーセント表示を行います
            string exp;
            double exp_next;
            if (neko[3] != "--")
            {
                exp = string.Format("{0:N0}", int.Parse(neko[3]));
                exp_next = double.Parse(neko[3]) / int.Parse(neko[4]) * 100;
            }
            else
            {
                exp = neko[3];
                exp_next = 100.0;
            }
            exp_next = Math.Round(exp_next, 1, MidpointRounding.AwayFromZero);
            //設定を行います
            Label lb = new()
            {
                Name = Job + "_Lv",
                Text = "Lv." + neko[2] + "(" + exp + " - " + exp_next + "%)",
                Location = new Point(15, Y),
                AutoSize = true
            };
            //管理用Listに追加します
            Class_Job_Label[Index].Add(lb);
        }

        Trust trust = new();
        private void Create_Trust_ID(string Job, int Y, int Index)
        {
            List<string> neko = Class_Job[Index];
            int Lv = int.Parse(neko[2]);
            string id = "";
            if (Lv != 80 && Lv >= 70 && Index <= 17)
            {
                if (Lv == 70)
                    id = "フェイス解放まで" + string.Format("{0:N0}", int.Parse(neko[4]) - int.Parse(neko[3]));
                else if (Lv < 73)
                    id = "ID: " + trust.id_name[0];
                else if (Lv < 75)
                    id = "ID: " + trust.id_name[1];
                else if (Lv < 77)
                    id = "ID: " + trust.id_name[2];
                else if (Lv < 79)
                    id = "ID: " + trust.id_name[3];
                else
                    id = "ID: " + trust.id_name[4];
            }
            Label lb = new()
            {
                Name = Job + "_Trust_ID",
                Text = id,
                Location = new Point(15, Y),
                AutoSize = true
            };
            Class_Job_Label[Index].Add(lb);
        }

        private void Create_Trust_Loop(string Job, int Y, int Index)
        {
            List<string> neko = Class_Job[Index];
            int Lv = int.Parse(neko[2]);
            int exp = 0;
            if (neko[3] != "--")
                exp = int.Parse(neko[3]);
            string loop = "";
            if (Lv != 80 && Lv >= 71 && Index <= 17)
            {
                switch (Lv)
                {
                    case 71:
                        loop = Math.Ceiling((trust.exp_Table[0] + trust.exp_Table[1] - exp) / (trust.id_exp[0] * 1.95)).ToString();
                        break;
                    case 72:
                        loop = Math.Ceiling((trust.exp_Table[1] - exp) / (trust.id_exp[0] * 1.95)).ToString();
                        break;
                    case 73:
                        loop = Math.Ceiling((trust.exp_Table[2] + trust.exp_Table[3] - exp) / (trust.id_exp[1] * 1.95)).ToString();
                        break;
                    case 74:
                        loop = Math.Ceiling((trust.exp_Table[3] - exp) / (trust.id_exp[1] * 1.95)).ToString();
                        break;
                    case 75:
                        loop = Math.Ceiling((trust.exp_Table[4] + trust.exp_Table[5] - exp) / (trust.id_exp[2] * 1.95)).ToString();
                        break;
                    case 76:
                        loop = Math.Ceiling((trust.exp_Table[5] - exp) / (trust.id_exp[2] * 1.95)).ToString();
                        break;
                    case 77:
                        loop = Math.Ceiling((trust.exp_Table[6] + trust.exp_Table[7] - exp) / (trust.id_exp[3] * 1.95)).ToString();
                        break;
                    case 78:
                        loop = Math.Ceiling((trust.exp_Table[7] - exp) / (trust.id_exp[3] * 1.95)).ToString();
                        break;
                    case 79:
                        loop = Math.Ceiling((trust.exp_Table[8] - exp) / (trust.id_exp[4] * 1.95)).ToString();
                        break;
                }
                loop = "周回回数: " + loop + "回";
            }
            Label lb = new()
            {
                Name = Job + "_Trust_Loop",
                Text = loop,
                Location = new Point(15, Y),
                AutoSize = true
            };
            Class_Job_Label[Index].Add(lb);
        }

        public void Initializing()
        {
            //表示中のコンポーネントを削除します
            foreach (Panel panel in Job_Group)
                panel.Controls.Clear();

            //HTML抽出情報保存Listを初期化します
            Job_level.Clear();
            Job_name.Clear();
            Job_exp.Clear();

            //クラス情報保存用Listを初期化します
            Class_Job.Clear();
            PLD.Clear();
            WAR.Clear();
            DRK.Clear();
            GNB.Clear();
            WHM.Clear();
            SCH.Clear();
            AST.Clear();
            MNK.Clear();
            DRG.Clear();
            NIN.Clear();
            SAM.Clear();
            BRD.Clear();
            MCN.Clear();
            DNC.Clear();
            BLM.Clear();
            SMN.Clear();
            RDM.Clear();
            BLU.Clear();
            CRP.Clear();
            BSM.Clear();
            ARM.Clear();
            GSM.Clear();
            LTW.Clear();
            WVR.Clear();
            ALC.Clear();
            CUL.Clear();
            MIN.Clear();
            BTN.Clear();
            FSH.Clear();

            //コンポーネント管理用Listを初期化します
            Class_Job_Label.Clear();
            PLD_Label.Clear();
            WAR_Label.Clear();
            DRK_Label.Clear();
            GNB_Label.Clear();
            WHM_Label.Clear();
            SCH_Label.Clear();
            AST_Label.Clear();
            MNK_Label.Clear();
            DRG_Label.Clear();
            NIN_Label.Clear();
            SAM_Label.Clear();
            BRD_Label.Clear();
            MCN_Label.Clear();
            DNC_Label.Clear();
            BLM_Label.Clear();
            SMN_Label.Clear();
            RDM_Label.Clear();
            BLU_Label.Clear();
            CRP_Label.Clear();
            BSM_Label.Clear();
            ARM_Label.Clear();
            GSM_Label.Clear();
            LTW_Label.Clear();
            WVR_Label.Clear();
            ALC_Label.Clear();
            CUL_Label.Clear();
            MIN_Label.Clear();
            BTN_Label.Clear();
            FSH_Label.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("表示した情報を削除します\nよろしいですか？",
                                                                             "Question",
                                                                             MessageBoxButtons.YesNo,
                                                                             MessageBoxIcon.Question,
                                                                             MessageBoxDefaultButton.Button2);
            if (result == DialogResult.OK)
                Initializing();
        }
    }
}
