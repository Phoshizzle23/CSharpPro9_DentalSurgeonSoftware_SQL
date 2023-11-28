using System.Data;
using System.Data.SqlClient;

namespace DentalSurgeon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-5KJ157N\\MATTDATABASEPRO;Initial Catalog=dentaldb;User ID=sa;Password=1234qwer");
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        void BindData()
        {

            SqlCommand cnn = new SqlCommand("Select * from dentaltb", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);

            DataTable table = new DataTable();

            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into dentaltb values(@clientid,@clientname,@age,@dentist,@phone,@status,@injury,@symptom,@treatment)", con);

            cnn.Parameters.AddWithValue("@ClientId", int.Parse(clientIdTxt.Text));

            cnn.Parameters.AddWithValue("@ClientName", clientNameTxt.Text);

            cnn.Parameters.AddWithValue("@Age", int.Parse(ageTxt.Text));

            cnn.Parameters.AddWithValue("@Dentist", dentistTxt.Text);

            cnn.Parameters.AddWithValue("@Phone", phoneTxt.Text);

            cnn.Parameters.AddWithValue("@Status", statusTxt.Text);

            cnn.Parameters.AddWithValue("@Injury", injuryTxt.Text);

            cnn.Parameters.AddWithValue("@Symptom", symptomTxt.Text);

            cnn.Parameters.AddWithValue("@Treatment", treatmentTxt.Text);

            cnn.ExecuteNonQuery();

            con.Close();

            BindData();

            MessageBox.Show("Record Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            clientIdTxt.Text = "";

            clientNameTxt.Text = "";

            ageTxt.Text = "";

            dentistTxt.Text = "";

            phoneTxt.Text = "";

            statusTxt.Text = "";

            injuryTxt.Text = "";

            symptomTxt.Text = "";

            treatmentTxt.Text = "";
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5KJ157N\\MATTDATABASEPRO;Initial Catalog=dentaldb;User ID=sa;Password=1234qwer");

            con.Open();

            SqlCommand cnn = new SqlCommand("delete dentaltb where clientid = @clientId", con);

            cnn.Parameters.AddWithValue("@ClientId", int.Parse(clientIdTxt.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            BindData();

            MessageBox.Show("Record Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}