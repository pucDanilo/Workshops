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