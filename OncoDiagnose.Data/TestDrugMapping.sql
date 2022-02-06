select d.Id as DrugId
		,c.Id as CancerTypeId
		,a.Id as AlterationId
		,a.GeneId as GeneId
		from
[dbo].[Drugs] as d inner join [dbo].[Treatments] as t on d.TreatmentId = t.Id
inner join [dbo].[Alterations] as a on t.MutationId = a.MutationId
inner join [dbo].[CancerTypes] as c on t.MutationId = c.MutationId
where GeneId = 1 and a.Id = 1 and c.Id = 82;
