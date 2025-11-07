// -- solucao.dart --
import 'package:json_annotation/json_annotation.dart';

part 'solucao.g.dart';

@JsonSerializable()
class Solucao {
	String soluctionName;
	Dbo[] dbo;

	Solucao({required this.soluctionName,required this.dbo,});

	factory Solucao.fromJson(Map<String, dynamic> json) => _$SolucaoFromJson(json);

	Map<String, dynamic> toJson() => _$SolucaoToJson(this);
}
// -- dbo.dart --
import 'package:json_annotation/json_annotation.dart';

part 'dbo.g.dart';

@JsonSerializable()
class Dbo {
	String projeto;
	Table[] table;

	Dbo({required this.projeto,required this.table,});

	factory Dbo.fromJson(Map<String, dynamic> json) => _$DboFromJson(json);

	Map<String, dynamic> toJson() => _$DboToJson(this);
}
// -- table.dart --
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
// -- index.dart --
import 'package:json_annotation/json_annotation.dart';

part 'index.g.dart';

@JsonSerializable()
class Index {
	String keyNameOf;
	String name;
	bool is_unique;
	bool is_primary_key;
	Column[] columns;

	Index({required this.keyNameOf,required this.name,required this.is_unique,required this.is_primary_key,required this.columns,});

	factory Index.fromJson(Map<String, dynamic> json) => _$IndexFromJson(json);

	Map<String, dynamic> toJson() => _$IndexToJson(this);
}
// -- column.dart --
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
// -- fk.dart --
import 'package:json_annotation/json_annotation.dart';

part 'fk.g.dart';

@JsonSerializable()
class Fk {
	int referenced_object_id;
	int referenced_column_id;
	String fK_CONSTRAINT;
	String referenced_column;
	String referenced_object;
	String parent_object;
	String parent_column;

	Fk({required this.referenced_object_id,required this.referenced_column_id,required this.fK_CONSTRAINT,required this.referenced_column,required this.referenced_object,required this.parent_object,required this.parent_column,});

	factory Fk.fromJson(Map<String, dynamic> json) => _$FkFromJson(json);

	Map<String, dynamic> toJson() => _$FkToJson(this);
}
// -- constraint.dart --
import 'package:json_annotation/json_annotation.dart';

part 'constraint.g.dart';

@JsonSerializable()
class Constraint {
	String name;
	String definition;

	Constraint({required this.name,required this.definition,});

	factory Constraint.fromJson(Map<String, dynamic> json) => _$ConstraintFromJson(json);

	Map<String, dynamic> toJson() => _$ConstraintToJson(this);
}
