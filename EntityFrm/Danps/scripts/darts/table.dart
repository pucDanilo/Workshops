import 'package:json_annotation/json_annotation.dart';

part 'table.g.dart';

@JsonSerializable()
class Table {
	String area;
	String tableNameOf;
	int id;
	String name;
	Index[] indexes;
	Column[] columns;

	Table({required this.area,required this.tableNameOf,required this.id,required this.name,required this.indexes,required this.columns,});

	factory Table.fromJson(Map<String, dynamic> json) => _$TableFromJson(json);

	Map<String, dynamic> toJson() => _$TableToJson(this);
}