# 设计描述
**Abstract:设计并完成电影类的查询和个性化推荐**</br>

**整体使用.net freamwork4.0实现**</br>
  1)C#严格面向对象编程语言，可进行迅速实现，并进行迭代；</br>
  2)dotNetRDF/VDS可将C#和Sparql进行完美结合，从而实现从http://dbpedia.org/ontology/获取数据并进行展示;</br>
  3)使用gridview呈现数据，完美展示数据组织形式以及组织结构;</br>

**测试阶段**</br>
   *通过get_data_spider.py 和get_data_sparql.py获取数据，此外，如果没有该数据，我们通过spider从百度文库上获取数据，经过测试之后，我们将Sparql语句集成到.net框架之中*</br>
**集成阶段1**</br>
   *通过将Sparql查询语句集成到.cs文件中，我们实现了根据用户输入，实现模糊查询的功能*</br>
**集成阶段2**</br>
   *通过将Sparql查询过滤语句集成到.cs文件中，我们实现了根据用户输入，实现根据用户的搜索类型进行智能推荐的功能*
