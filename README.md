In this kata we are going to mimic a software versioning system.

You have to implement a vm function returning an object.

It should accept an optional parameter that represents the initial version.
The input will be in one of the following
formats: "{MAJOR}" , "{MAJOR}.{MINOR}" , or "{MAJOR}.{MINOR}.{PATCH}" .
More values may be provided after PATCH but they should be ignored. If
these 3 parts are not decimal values, an exception with the message "Error
occured while parsing version!" should be thrown. If the initial version is
not provided or is an empty string, use "0.0.1" by default.

This class should support the following methods, all of which should be
chainable (except release ):

• <b>major()</b> - increase MAJOR by 1 , set MINOR and PATCH to 0<br />
• <b>minor()</b> - increase MINOR by 1 , set PATCH to 0<br />
• <b>patch()</b> - increase PATCH by 1<br />
• <b>rollback()</b> - return the MAJOR , MINOR , and PATCH to their values<br />

before the previous major / minor / patch call, or throw an exception
with the message "Cannot rollback!" if there's no version to roll
back to. Multiple calls to rollback() should be possible and restore
the version history<br />
• <b>release()</b> - return a string in the format "{MAJOR}.{MINOR}.{PATCH}"
