 select  campaignid, sum(totalsales) as TotalSales
 from adicampaign where date >  GETDATE()-10000
 group by campaignid
 order by campaignid

 Write a query to show keywords with highest sales
 for each store for the last 30 days  for optimized campaigns 


 select top 1 k.keywordid, k.totalsales
from adicampaign c inner join  adikw k on c.campaignid=k.campaignid
where c.status='TRUE' and c.date > GETDATE()-100000
 order by  k.totalsales ASC

  select top 1 k.keywordid, k.totalsales
from adicampaign c inner join  adikw k on c.campaignid=k.campaignid
where c.optimized='TRUE' and k.date > GETDATE()-30
 order by  k.totalsales DESC 

 

Write a query to show the CTR
(Click through rates) for each  enabled and optimized campaign? 

select campaignid, ([clicks]/impression) as CTR 
from adicampaign
where optimized='TRUE' and status='Enabled'

Write a query to show the most
viewed(impressions) campaign
for each store for the last year 

select storeid, campaignid, impression from adicampaign
where date = Convert(date, (DATEADD(year, -9, getdate())))
 order by impression DESC 