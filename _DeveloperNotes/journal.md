
Tuesday 28 August 2018

It might be worth moving `react-components` out of `wwwsrc` and into a sibling project. 

    src/
       aspnet/ <--- the aspnet source
       react/  <--- the react components

Monday 13 August 2018

Sqlite does not support the AlterColumnOperation. This is going to make Entity Framework difficult, because it will involve rebuilding changed tables.

It would be nice to add a src/ directory that separates the apps source files from other files. This might require updating the deploy.cmd script.

Saturday 11 August 2018

We will soon need to determine how to do continuous deployment without clobbering the database each time.

It might be worth removing the bootstrap classes from the HTML and instead using SASS overrides.

It might be worth introducing a <nav-item> tag helper. That would lead to more consise `*.cshtml` pages.

Wednesday 08 August 2018

We could improve the web document citation and reference list to include the sub-section of the work.

Wednesday 01 August 2018

A good goal would be to add five forms to /Tools and then to start optimizing/refactoring.

Tuesday 31 July 2018

Shorter URLs to the tools would be nice. E.g. socialarts.club/as for the assertiveness scorecard

Listing all the tools on the home/landing page would be nice.

Setting the focus to each form's first input would be nice.
