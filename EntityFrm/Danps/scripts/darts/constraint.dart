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