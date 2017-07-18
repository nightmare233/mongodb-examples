using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB
{
    class Program
    {
        //链接字符串
        private static string connectionString = "mongodb://localhost";
        //数据库名
        private static string databaseName = "myDatabase";
        //集合名
        private static string collectionName = "myCollection";

        static void Main(string[] args)
        { 
            Mongo mongo = new Mongo(connectionString);
            //定义一个文档对象，存入两个键值对
            mongo.Connect();
            //获取databaseName对应的数据库，不存在则自动创建
            MongoDatabase mongoDatabase = mongo.GetDatabase(databaseName) as MongoDatabase;
            //获取collectionName对应的集合，不存在则自动创建
            MongoCollection<Document> mongoCollection = mongoDatabase.GetCollection<Document>(collectionName) as MongoCollection<Document>;
            try
            { 
                Document doc = new Document();
                doc["ID"] = 1;
                doc["Msg"] = "Hello World!";

                //将这个文档对象插入集合
                mongoCollection.Insert(doc);
                //在集合中查找键值对为ID=1的文档对象
                Document docFind = mongoCollection.FindOne(new Document { { "ID", 1 } });
                //输出查找到的文档对象中键“Msg”对应的值，并输出
                Console.WriteLine(Convert.ToString(docFind["Msg"]));
            }
            finally
            {
                //关闭链接
                mongo.Disconnect();
            }
        }

         
    }
}
