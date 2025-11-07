
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