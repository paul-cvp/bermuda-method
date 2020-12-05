SELECT DISTINCT [] as 'CitizenID'
      ,[] as 'Event'
      ,FORMAT([],'yyyy/MM/dd HH:mm:ss') as 'Start'
      ,FORMAT([],'yyyy/MM/dd HH:mm:ss') as 'End'
	  ,[] as 'EventExtraFeature'
	  ,DATEDIFF(DAY, [], []) as 'DurationDays'
	  ,[] as 'CaseID'
	  ,[] as 'Discriminator'
  FROM []