select Count(*) as Searches, CAST( FLOOR( CAST( [Timestamp] AS FLOAT ) ) AS DATETIME ) as [Day] from Log
where type = 'search'
group by CAST( FLOOR( CAST( [Timestamp] AS FLOAT ) ) AS DATETIME )
order by CAST( FLOOR( CAST( [Timestamp] AS FLOAT ) ) AS DATETIME ) desc
