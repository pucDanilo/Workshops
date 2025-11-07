
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