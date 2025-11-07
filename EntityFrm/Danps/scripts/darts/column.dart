
import 'package:json_annotation/json_annotation.dart';

part 'column.g.dart';

@JsonSerializable()
class Column {
	String ownsOne;
	String columnNameOf;
	int id;
	String name;
	String type;
	int max_length;
	Index[] indexes;
	Fk[] fks;
	Constraint[] constraints;

	Column({required this.ownsOne,required this.columnNameOf,required this.id,required this.name,required this.type,required this.max_length,required this.indexes,required this.fks,required this.constraints,});

	factory Column.fromJson(Map<String, dynamic> json) => _$ColumnFromJson(json);

	Map<String, dynamic> toJson() => _$ColumnToJson(this);
}