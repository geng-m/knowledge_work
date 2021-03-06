﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VDS.RDF.Query;
using VDS.RDF.Parsing;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

public partial class Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                getData("Star_Wars");

            }
            catch
            {
                getData(this.txt_recommond.Text.Trim());
            }
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        string label = this.txt_recommond.Text.Trim();
        getData(label);
    }
    public void getData(string label)
    {
        SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        string query_str = "PREFIX dbo:<http://dbpedia.org/ontology/>  SELECT  COUNT(?movie) SAMPLE(?movie) WHERE{ dbr:Star_Wars dct:subject ?o .?movie dct:subject ?o FILTER (?movie != dbr:Star_Wars).} GROUP BY ?movie ORDER BY DESC(COUNT(?movie)) LIMIT 100";
        SparqlResultSet results = endpoint.QueryWithResultSet(query_str);
        DataTable dt = new DataTable();
        DataColumn dc1 = new DataColumn("callret-0", Type.GetType("System.String"));
        DataColumn dc2 = new DataColumn("callret-1", Type.GetType("System.String"));

        dt.Columns.Add(dc1);
        dt.Columns.Add(dc2);
        Dictionary<string, int> d = new Dictionary<string, int>();
        foreach (SparqlResult row in results)
        {
            DataRow dr = dt.NewRow();
            dr["callret-0"] = Convert.ToString(row[0]).Split('^')[0];
            string key = Convert.ToString(row[0]).Split('^')[0];
            dr["callret-1"] = row[1];
            dt.Rows.Add(dr);

            if (d.Keys.Contains(key))
            {
                d[key] += 1;
            }
            else {
                d.Add(key,1);
            }
        }
        this.grid_data.DataSource = dt;
        this.grid_data.DataBind();

        chart_show.Series.Clear();
        Series Strength = new Series("similar");
        Strength.ChartType = SeriesChartType.Column;
        foreach(string key in d.Keys){
            Strength.Points.AddXY(key, d[key]);
        }
        Strength.IsValueShownAsLabel = true;
        chart_show.ChartAreas[0].AxisX.Title = "相似程度";
        chart_show.ChartAreas[0].AxisY.Title = "个数";

        chart_show.Series.Add(Strength);
    }
}