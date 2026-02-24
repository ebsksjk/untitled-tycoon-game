# kunde

es können n kunden gleichzeitig im laden sein

ein kunde hat eine einkaufsliste:
 - diese besteht aus randomly ausgewählten waren

ein kunde hat eine rate, die der festgelegte preis vom base verkaufspreis abweichen darf, bevor er das produkt nicht mehr kauft

ein kunde hat eine liste von optionalen waren, die er ggf mitnehmen würde
ein kunde hat eine "incentive" variable
gegen diese wird, sind waren im sonderangebot, ein check gemacht. ist dieser check erfolgreich, kauft der kunde die ware


ein kunde hat eine zufriedenheit. diese wird beeinflusst, indem waren auf der einkaufsliste in stock sind, der laden sauber ist und ggf zusätzliche modifier (events)
negativ beeinflusst wird diese durch fehlende waren, unsauberer laden, zu hohe preise oder überschrittenes mhd von verräumten waren

kunden haben eine percentage, wiederzukehren und dabei potentiell längere einkaufslisten zu haben und ist more likely spontankäufe zu machen 
ein stammkunde gehört nicht zum kundenlimit

(pathfinding? kann der kunde ein produkt nach x einheiten nicht finden, verringert sich seine zufriedenheit)
(pathfinding kann auch ein gedächtnis haben. ständig umräumen ist unpopulär)
