using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace IndirektBend.Admin
{
    public partial class Admin : System.Web.UI.Page
    {
        // Connection string staviti u konekciju
        SqlConnection connection = new SqlConnection("");
        protected void Page_Load(object sender, EventArgs e)
        {
            UcitajListuInstrumenata();
            UcitajSvirace();
            UcitajInstrumente();
            UcitajSvirke();
        }

        protected void UcitajListuInstrumenata()
        {
            if(!IsPostBack)
            {
                try
                {
                    connection.Open();
                    string upit = "SELECT naziv FROM instrument";
                    SqlCommand command = new SqlCommand(upit, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        DropDownList1.Items.Add(reader[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        protected void UcitajSvirace()
        {
            try
            {
                connection.Open();
                string upit = "SELECT * FROM Svirac";
                SqlDataAdapter adapter = new SqlDataAdapter(upit, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                GridView1.DataSource = table;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void UcitajInstrumente()
        {
            try
            {
                connection.Open();
                string upit = "SELECT * FROM Instrument";
                SqlDataAdapter adapter = new SqlDataAdapter(upit, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                GridView2.DataSource = table;
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void UcitajSvirke()
        {
            try
            {
                connection.Open();
                string upit = "SELECT * FROM Svirke ORDER BY datum ASC";
                SqlDataAdapter adapter = new SqlDataAdapter(upit, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                GridView3.DataSource = table;
                GridView3.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(GridView1.SelectedRow != null)
            {
                TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
                TextBox2.Text = GridView1.SelectedRow.Cells[2].Text;
                DropDownList1.SelectedValue = GridView1.SelectedRow.Cells[3].Text;
            }
            else
            {
                SviracError.Text = "Izaberite red";
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView2.SelectedRow != null)
            {
                TextBox3.Text = GridView2.SelectedRow.Cells[1].Text;
                TextBox4.Text = GridView2.SelectedRow.Cells[2].Text;
            }
            else
            {
                InstrumentError.Text = "Izaberite red";
            }
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView3.SelectedRow != null)
            {
                TextBox5.Text = GridView3.SelectedRow.Cells[1].Text;
                TextBox6.Text = GridView3.SelectedRow.Cells[2].Text;
                TextBox7.Text = GridView3.SelectedRow.Cells[3].Text;
            }
            else
            {
                SvirkaError.Text = "Izaberite red";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Unos sviraca

            if(TextBox2.Text == "")
            {
                SviracError.Text = "Popunite polja";
                return;
            }

            try
            {
                connection.Open();

                SqlParameter p1 = new SqlParameter();
                SqlParameter p2 = new SqlParameter();

                p1.Value = TextBox2.Text;
                p2.Value = DropDownList1.SelectedItem.Value;

                p1.ParameterName = "imePrezime";
                p2.ParameterName = "instrument";

                string upit = "INSERT INTO Svirac (imePrezime,instrument) VALUES (@imePrezime, @instrument)";
                SqlCommand command = new SqlCommand(upit, connection);
                command.Parameters.Add(p1);
                command.Parameters.Add(p2);

                command.ExecuteNonQuery();

                Response.Redirect("~/Admin/Admin.aspx", false);
            }
            catch (Exception ex)
            {
                SviracError.Text = "Greska";
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Update svirac

            if (TextBox2.Text == "" || GridView1.SelectedRow == null)
            {
                SviracError.Text = "Popunite polja ili izaberite red";
                return;
            }

            try
            {
                connection.Open();

                SqlParameter p1 = new SqlParameter();
                SqlParameter p2 = new SqlParameter();

                p1.Value = TextBox2.Text;
                p2.Value = DropDownList1.SelectedItem.Value;

                p1.ParameterName = "imePrezime";
                p2.ParameterName = "instrument";

                string upit = "UPDATE Svirac SET imePrezime = @imePrezime, instrument = @instrument WHERE sviracID = " + GridView1.SelectedRow.Cells[1].Text;
                SqlCommand command = new SqlCommand(upit, connection);
                command.Parameters.Add(p1);
                command.Parameters.Add(p2);

                command.ExecuteNonQuery();

                Response.Redirect("~/Admin/Admin.aspx", false);
            }
            catch (Exception ex)
            {
                SviracError.Text = "Greska";
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // Delete svirac
            if (GridView1.SelectedRow == null)
            {
                SviracError.Text = "Izaberite red";
                return;
            }

            try
            {
                connection.Open();

                SqlParameter p1 = new SqlParameter();

                p1.Value = GridView1.SelectedRow.Cells[1].Text;
                p1.ParameterName = "sviracID";

                string upit = "DELETE FROM Svirac WHERE sviracID = @sviracID";
                SqlCommand command = new SqlCommand(upit, connection);
                command.Parameters.Add(p1);

                command.ExecuteNonQuery();

                Response.Redirect("~/Admin/Admin.aspx", false);
            }
            catch (Exception ex)
            {
                SviracError.Text = "Greska";
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            // Unos instrumenta

            if (TextBox4.Text == "")
            {
                InstrumentError.Text = "Popunite polja";
                return;
            }

            try
            {
                connection.Open();

                SqlParameter p1 = new SqlParameter();

                p1.Value = TextBox4.Text;
                p1.ParameterName = "naziv";

                string upit = "INSERT INTO Instrument (naziv) VALUES (@naziv)";
                SqlCommand command = new SqlCommand(upit, connection);
                command.Parameters.Add(p1);

                command.ExecuteNonQuery();

                Response.Redirect("~/Admin/Admin.aspx", false);
            }
            catch (Exception ex)
            {
                InstrumentError.Text = "Greska";
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            // Update instrumenta

            if (TextBox4.Text == "" || GridView2.SelectedRow == null)
            {
                InstrumentError.Text = "Popunite polja ili izaberite red";
                return;
            }

            try
            {
                connection.Open();

                SqlParameter p1 = new SqlParameter();

                p1.Value = TextBox4.Text;
                p1.ParameterName = "naziv";

                string upit = "UPDATE Instrument SET naziv = @naziv WHERE instrumentID = " + GridView2.SelectedRow.Cells[1].Text;
                SqlCommand command = new SqlCommand(upit, connection);
                command.Parameters.Add(p1);

                command.ExecuteNonQuery();

                Response.Redirect("~/Admin/Admin.aspx", false);
            }
            catch (Exception ex)
            {
                InstrumentError.Text = "Greska";
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            // Delete instrumenta

            if (GridView2.SelectedRow == null)
            {
                InstrumentError.Text = "Popunite polja ili izaberite red";
                return;
            }

            try
            {
                connection.Open();

                SqlParameter p1 = new SqlParameter();

                p1.Value = GridView2.SelectedRow.Cells[1].Text;
                p1.ParameterName = "instrumentID";

                string upit = "DELETE FROM Instrument WHERE instrumentID = @instrumentID";
                SqlCommand command = new SqlCommand(upit, connection);
                command.Parameters.Add(p1);

                command.ExecuteNonQuery();

                Response.Redirect("~/Admin/Admin.aspx", false);
            }
            catch (Exception ex)
            {
                InstrumentError.Text = "Greska";
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            // Unesi svirku

            if (TextBox6.Text == "" || TextBox7.Text == "")
            {
                SvirkaError.Text = "Popunite polja";
                return;
            }

            if(!TextBox7.Text.Contains('-')) 
            {
                SvirkaError.Text = "Datum nije u dobrom formatu.";
                return;
            }

            try
            {
                connection.Open();

                SqlParameter p1 = new SqlParameter();
                SqlParameter p2 = new SqlParameter();

                p1.Value = TextBox6.Text;
                p1.ParameterName = "lokacija";

                p2.Value = TextBox7.Text;
                p2.ParameterName = "datum";

                string upit = "INSERT INTO Svirke (lokacija, datum) VALUES (@lokacija, @datum)";
                SqlCommand command = new SqlCommand(upit, connection);
                command.Parameters.Add(p1);
                command.Parameters.Add(p2);

                command.ExecuteNonQuery();

                Response.Redirect("~/Admin/Admin.aspx", false);
            }
            catch (Exception ex)
            {
                SvirkaError.Text = "Greska";
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            // Update svirku
            if (TextBox6.Text == "" || TextBox7.Text == "" || GridView3.SelectedRow == null)
            {
                SvirkaError.Text = "Popunite polja ili izaberite red.";
                return;
            }

            if (!TextBox7.Text.Contains('-'))
            {
                SvirkaError.Text = "Datum nije u dobrom formatu.";
                return;
            }

            try
            {
                connection.Open();

                SqlParameter p1 = new SqlParameter();
                SqlParameter p2 = new SqlParameter();

                p1.Value = TextBox6.Text;
                p1.ParameterName = "lokacija";

                p2.Value = TextBox7.Text;
                p2.ParameterName = "datum";

                string upit = "UPDATE Svirke SET lokacija = @lokacija, datum = @datum WHERE svirkaID = " + GridView3.SelectedRow.Cells[1].Text;
                SqlCommand command = new SqlCommand(upit, connection);
                command.Parameters.Add(p1);
                command.Parameters.Add(p2);

                command.ExecuteNonQuery();

                Response.Redirect("~/Admin/Admin.aspx", false);
            }
            catch (Exception ex)
            {
                SvirkaError.Text = "Greska";
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            // Delete svirku

            if (GridView3.SelectedRow == null)
            {
                SvirkaError.Text = "Izaberite red.";
                return;
            }

            try
            {
                connection.Open();

                SqlParameter p1 = new SqlParameter();

                p1.Value = GridView3.SelectedRow.Cells[1].Text;
                p1.ParameterName = "svirkaID";

                string upit = "DELETE FROM Svirke WHERE svirkaID = @svirkaID";
                SqlCommand command = new SqlCommand(upit, connection);
                command.Parameters.Add(p1);

                command.ExecuteNonQuery();

                Response.Redirect("~/Admin/Admin.aspx", false);
            }
            catch (Exception ex)
            {
                SvirkaError.Text = "Greska";
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}