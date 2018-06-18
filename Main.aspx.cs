using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VDS.RDF.Query;
using VDS.RDF.Parsing;
using System.Data;

public partial class Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                getData("War");

            }
            catch {
                getData(this.txt_search.Text.Trim());
            }
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        string name = this.txt_search.Text.Trim();
        getData(name);
    }
    public void getData(string name) 
    { 
        SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        string query_str = "PREFIX dbo:<http://dbpedia.org/ontology/>  SELECT * WHERE{ ?url rdf:type<http://dbpedia.org/ontology/Film>;rdfs:label ?label;foaf:name ?name;dbo:wikiPageID ?wikiPageID;dbo:abstract ?abstract OPTIONAL{?url dbo:writer ?writer} filter regex(?label,'en') filter regex(?name,'" + name + "')}";
        SparqlResultSet results = endpoint.QueryWithResultSet(query_str);

        DataTable dt = new DataTable();
        DataColumn dc1 = new DataColumn("url", Type.GetType("System.String"));
        DataColumn dc2 = new DataColumn("label", Type.GetType("System.String"));
        DataColumn dc3 = new DataColumn("name", Type.GetType("System.String"));
        DataColumn dc4 = new DataColumn("wikiPageID", Type.GetType("System.String"));
        DataColumn dc5 = new DataColumn("abstract", Type.GetType("System.String"));
        DataColumn dc6 = new DataColumn("writer", Type.GetType("System.String"));

        dt.Columns.Add(dc1);
        dt.Columns.Add(dc2);
        dt.Columns.Add(dc3);
        dt.Columns.Add(dc4);
        dt.Columns.Add(dc5);
        dt.Columns.Add(dc6);

        //int index = 0;
        foreach (SparqlResult row in results)
        {
            DataRow dr = dt.NewRow();
            dr["url"] = row[0];
            dr["label"] = row[1];
            dr["name"] = row[2];
            dr["wikiPageID"] = row[3];
            string str_abstrict = Convert.ToString(row[4]);
            if (str_abstrict.Length > 56)
            {
                dr["abstract"] = str_abstrict.Substring(0, 56);
            }
            else {
                dr["abstract"] = str_abstrict;
            }
            dr["writer"] = row[5];
            dt.Rows.Add(dr);
            //index += 1;
            //if (index == 100)
            //{
            //    break;
            //}

        }
        this.grid_data.DataSource = dt;
        this.grid_data.DataBind();
    }
}