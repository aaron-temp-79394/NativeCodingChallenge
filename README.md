
# Instructions
- You will need Visual Studio to complete challenges outlined below. We suggest you utilize one of the community editions provided at https://www.visualstudio.com/downloads/
- Clone this repo to your local machine
- Use it to create a new repo on GitHub under your own account (please don't use GitHub fork to accomplish this)
- Complete the challenge below or provide an alternative representative sample of code or classes that is solely your work product. 
  (If you maintain a github project where you are the sole contributor, please feel free to submit a link and description of what we should review in the repository.)
- Send us an email with a link to your repo and any instructions or details you want to share about key features, performance optimizations or creative problem solving skills that they exemplify.

## Also Energy Code Challenge

### Please review the projects in the Challenge solution and perform the following tasks. Please feel free to be creative and simplify when possible. 

1) Fix the bug causing the existing unit test to fail.
   - Completed, unit tests pass with changes to tested code only (no changes to existing unit tests)

2) Add a PermissionSet class to hold a fixed list of 100 user permissions (i.e. perm1, perm2, ...). 

   The PermissionSet should be able to serialize/deserialize as a byte array.
   - Completed, with unit tests for code coverage

3) Provide a brief comment for each of the following:

   - Concept or element that was unfamiliar or unexpected
      - The Challenge project type of SQL Server 2016 was unexpected.

   - Constructive review or recommended improvement
      - As possible, separate concerns. In other words, make methods more self-contained, and divide up the large unit test into smaller ones that focus on one responsibility each.

   - Opportunity or future enhancement
      - I think the most important opportunity (greatest yield per effort) is putting similar or corresponding logic blocks into their own classes. For example, the unit tests failed because blob *import* used a different encoding than *export*. Import/export operations usually share a lot of the same logic, so it might be worth condensing that logic instead of keeping it separated. I know at first that seems to argue against my earlier point about separation of concerns, but I'm actually arguing for a different point: if the same encoding is used for import as for export, that encoding should be in one place in code - not in two. That way, import and export can both rely on this single source of truth, and import and export can still be tested as separate units.