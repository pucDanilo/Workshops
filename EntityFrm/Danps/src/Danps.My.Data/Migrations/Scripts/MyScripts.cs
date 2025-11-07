namespace Danps.Core.My.Scripts
{
    public class MyScripts
    {
        public static string DROP_ALL_MY_TABLES => @"
DROP TABLE IF EXISTS my_aggregate_class
DROP TABLE IF EXISTS my_aggregate
DROP TABLE IF EXISTS my_class_foreign_key
DROP TABLE IF EXISTS my_replace
DROP TABLE IF EXISTS my_class_field
DROP TABLE IF EXISTS my_class
DROP TABLE IF EXISTS my_tag
DROP TABLE IF EXISTS my_modelo

";
    }
}