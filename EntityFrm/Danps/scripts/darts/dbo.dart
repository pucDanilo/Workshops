
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