(deftemplate factor_Time
	0 60 Minutes
	(
		(slot1 (Z 0 10))
		(slot2 (PI 5 10))
		(slot3 (PI 5 20))
		(slot4 (PI 5 30))
		(slot5 (PI 5 40))
		(slot6 (PI 5 50))
		(slot7 (S 50 60))
	)
)

(deftemplate case_output
	(slot ID)
	(slot time (type FUZZY-VALUE factor_Time))
)

