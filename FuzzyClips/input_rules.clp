(defrule Slot_Num_1_Rule_Num_1
	(sharedfile ?path)
	(case
		(id ?id)
		(Age elder)
		(height Medium)
	)
	=>
	(assert(case_output (id ?id) (time slot1) ))
	(save-facts ?path visible case_output)
)

(defrule Slot_Num_1_Rule_Num_2
	(sharedfile ?path)
	(case
		(id ?id)
		(height tall)
	)
	=>
	(assert(case_output (id ?id) (time slot1) ))
	(save-facts ?path visible case_output)
)

(defrule Slot_Num_2_Rule_Num_1
	(sharedfile ?path)
	(case
		(id ?id)
		(Age Adult)
		(height Medium)
	)
	=>
	(assert(case_output (id ?id) (time slot2) ))
	(save-facts ?path visible case_output)
)

