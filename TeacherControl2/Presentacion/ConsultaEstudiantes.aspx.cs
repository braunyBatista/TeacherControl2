﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegEstudiantes.Presentacion {
    public partial class ConsultaEstudiantes : System.Web.UI.Page {
        string filtro = "1=1";
        protected void Page_Load(object sender, EventArgs e) {

            if (Request.QueryString["Consulta"] != null)
            { 
                filtro= Request.QueryString["Consulta"];
                DatosGridView.DataSource = BLL.Estudiantes.StaticListar(filtro);
                DatosGridView.DataBind();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e) {

            if (EstudiantesDropDownList.SelectedIndex == 1)
                filtro += "and Nombres like '%" + BuscarTextBox.Text + "%'";
            else if (EstudiantesDropDownList.SelectedIndex == 2)
                filtro += "and Matricula like '%" + BuscarTextBox.Text + "%'";
           
            DatosGridView.DataSource = BLL.Estudiantes.StaticListar(filtro);
            DatosGridView.DataBind();
        }

        protected void EstudiantesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(EstudiantesDropDownList.SelectedIndex == 3 )
            {
                Response.Redirect("ConsultaFecha.aspx");
            }
            else
            {
                BuscarTextBox.ReadOnly = false;
            }
        }
    }
}