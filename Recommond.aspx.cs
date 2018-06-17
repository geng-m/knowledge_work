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
        getData("");
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        string label = this.txt_recommond.Text.Trim();
        getData(label);
    }
    public void getData(string label) 
    { 
        SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        string query_str = "PREFIX dbo:<http://dbpedia.org/ontology/>  SELECT * WHERE{ ?url rdf:type<http://dbpedia.org/ontology/Film>;rdfs:label ?label;foaf:name ?name;dbo:wikiPageID ?wikiPageID;dbo:abstract ?abstract OPTIONAL{?url dbo:writer ?writer} filter regex(?label,'"+label+"')}";
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

        foreach (SparqlResult row in results)
        {
            DataRow dr = dt.NewRow();
            dr["url"] = row[0];
            dr["label"] = row[1];
            dr["name"] = row[2];
            dr["wikiPageID"] = row[3];
            dr["abstract"] = Convert.ToString(row[4]).Substring(0, 56);
            dr["writer"] = row[5];
            dt.Rows.Add(dr);

        }
        this.grid_data.DataSource = dt;
        this.grid_data.DataBind();
    }
}