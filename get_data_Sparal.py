# coding: UTF-8
from SPARQLWrapper import SPARQLWrapper, JSON
from PublicationSR.pachong import get_infor


def get_content_list(searchtxt):
    query_str = """
        PREFIX dbo:<http://dbpedia.org/ontology/>
        SELECT * WHERE{
            ?url rdf:type<http://dbpedia.org/ontology/Book>;
            rdfs:label ?label;
            foaf:name ?name;
            dbo:wikiPageID ?wikiPageID;
            dbo:abstract ?abstract
            OPTIONAL{?url dbo:writer ?writer}
            filter regex(str(?label), '""" + searchtxt + "')}"
    sparql = SPARQLWrapper("http://dbpedia.org/sparql")
    sparql.setQuery(query_str)
    sparql.setReturnFormat(JSON)
    result = sparql.query().convert()

    table = []
    wikiPageIDs = []
    for item in result["results"]["bindings"]:
        now_item = []
        wikiPageID = item["wikiPageID"]["value"]
        if (wikiPageID not in wikiPageIDs):
            wikiPageIDs.append(wikiPageID)
        else:
            continue

        url = item["url"]["value"]
        now_item.append(url)

        label = item["label"]["value"]
        now_item.append(label)

        now_item.append(show_property(item, "name"))
        now_item.append(show_property(item, "writer"))

        abstract = show_property(item, "abstract")
        strlen = len(abstract)
        if strlen > 50:
            abstract = str(abstract)[0:150] + "..."
        now_item.append(abstract)
        table.append(now_item)
    return table


def show_property(item, propertyname):
    try:
        property = item[propertyname]["value"]
    except KeyError:
        property = ""
    return property
