DIY Process List
================

This project is a test assignment I have completed as a part of a job-hiring
process I was once encountered in. What I was asked was to demonstrate my
skills in .NET and C#, with a slight emphasis on reflection techniques.

Despite I spent whole day writing code and designing UI, the final program
is hardly useful for anyone's daily tasks. However, its code contains
a bunch of helper subroutines which I think may be worth reusing by me
or someone else.


Implementation notes
--------------------

* I didn't use XML comments intentionally. Of course, I know how to use them,
  but in this project the only thing they're going to do is to spoil the code
  appearance.

* Exception handling is quite optimistic in many places, but what are we
  going to do if, say, 'Expression.Lambda' fails? Only die; so let the
  program fail fast.

* There is a plenty of room for UI improvements. For example, I could make
  current process selection persist during the listbox update, or add
  more columns, configurable via header's context menu. Next time, maybe.


Authors
-------

I wasn't paid for completing this test assignment, so I retain all copyright
for the work. However, I was asked not to disclose the company's exact name
and problem formulation text.

(c) Pavel Kretov, 2016.

This work provided under the terms of WTFPL or MIT license (you are free to
choose the one which suits your needs better).

