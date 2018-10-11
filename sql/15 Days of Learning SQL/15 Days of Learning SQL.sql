;with cte_date_grp as (
	select 
		row_day = ROW_NUMBER () OVER (ORDER BY submission_date asc)
		,[submission_date] ,count(*) as cnt_grp
		
	from Submissions
	group by [submission_date]
)
,cte_hacker_grp as (
	SELECT
        row_day = ROW_NUMBER () OVER (PARTITION BY hacker_id ORDER BY submission_date asc)  
        , ROWID=ROW_NUMBER () OVER (PARTITION BY submission_date ORDER BY count(*) desc,[hacker_id] asc) 		
        ,[submission_date],hacker_id
        ,COUNT(hacker_id) as cnt_per_day      	
	FROM Submissions
	group by [submission_date],hacker_id
)
,cte3 as (
    select cte_date_grp.row_day,cte_date_grp.submission_date,count(hacker_id) as cnt_hackers_ct
    from cte_date_grp  
    inner join cte_hacker_grp on cte_date_grp.row_day=cte_hacker_grp.row_day and cte_date_grp.submission_date=cte_hacker_grp.submission_date
    group by cte_date_grp.row_day,cte_date_grp.submission_date
)


select  cte_hacker_grp.submission_date,cte3.cnt_hackers_ct as perday,[Hackers].hacker_id,[Hackers].name 
from cte_hacker_grp 
inner join cte3 on cte_hacker_grp.submission_date=cte3.submission_date
inner join [Hackers] on cte_hacker_grp.hacker_id=[Hackers].hacker_id
where ROWID =1 
order by cte_hacker_grp.[submission_date]
