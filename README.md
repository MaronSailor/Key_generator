# Key_generator
Program made via C#
User gets random number of keys. Keys look like X12345Y[001] where the first part is the key and [001] is an id of the key.
The keys will be sorted after the alphabet and the user gets a chance to find a key's information.
For example: 
  1. user gets keys         R10708N[001] Y61595I[002] F59538U[003] U77536P[004] F16192P[005]
  2. they will be sorted as F16192P[005] F59538U[003] R10708N[001] U77536P[004] Y61595I[002]
  3. user writes in ID or the key he wants to find. F.e. R10708N[001] and because of this he writes 001 or R10708N to find it.
  4. user gets information about this key:
4.1.  SID (Starting_ID) - where the key was before sorting<br />
4.2.  CID (Current_ID)  - where the key is placed now<br />
4.3.  LINE              - line where the key is now<br />
4.4.  ROW               - row where the key is now<br />

So fot R10708N[001] the information will be SID - 001, CID - 003, LINE - 1, ROW - 3

It is good when there are more than hundred of keys and User needs one defined key in the list to be found.
