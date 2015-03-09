;(set-threshold 0.6)
;(disable-cf-rule-calculation)


(defrule test
	(SharedFile ?path)
	(case
		(ID ?id)
		(height Short)
	)
	=>
	(assert(case_output (ID ?id) (time slot1) ))
	(save-facts ?path visible case_output)
)

(defrule test1
	(SharedFile ?path)
	(case
		(ID ?id)
		(height tall)
	)
	=>
	(assert(case_output (ID ?id) (time slot6) ))
	(save-facts ?path visible case_output)
)
