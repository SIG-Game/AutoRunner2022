# Contributing
Please read this document in its entirety before contributing to the repository.

## Workflow
1. Assign yourself to an issue on the Issues tab of the GitHub repository. You should prioritize issues with higher priority tags. If there are any open blocking issues in the issue description, you should probably work on an unblocked issue instead.
2. Create a new branch based on the `premain` branch with the name format (ISSUE NUMBER)\_(BRIEF ISSUE DESCRIPTION). For example, the name of a branch adding player movement for issue number 1 could be `1_PlayerMovement`. (You could also create a fork of the repository if you don't have permission to create a branch, but you should message the #sig-game Discord channel to request permission instead.)
3. Once you have committed changes to your branch that resolve the issue, merge `premain` into your branch, resolve any merge conflicts, and open a pull request targeting `premain`.
4. Reviewers will assign themselves to your pull request. Two approvals are required before merging to the `premain` branch. Reviewers will not make changes to your branch, so please respond to reviewers' questions and make any requested changes as soon as possible.

### Issue Creation
If you want to make a change that doesn't have an issue, then create an issue for that change before going through the above steps. You should assign a prioritization tag and list any blocking issues. Send the issue to the #sig-game channel in case any changes are needed.

### Requesting Help
If you need clarification on an issue or would like additional help, please ask in the #sig-game channel immediately.

### Additional Pull Request Info
- **Do not push to `premain` or `main` directly without permission.** Changes should be made to feature branches with a corresponding issue.
- **Any pull requests that change the Unity version will be declined.** Please ensure the Unity version on your branch in `ProjectSettings/ProjectVersion.txt` is the same as the version in in that file on `premain`, which is `2021.3.1f1`. If you accidentally change the version, you should be able to revert that version change by opening the project in the correct version of Unity.
- If there are any merge conflicts between your branch and `premain`, then you must merge `premain` into your branch for your corresponding pull request to be reviewed.
- If the branch name does not have the format described above in step 2, your pull request will be declined. You can move your changes to a branch with the correct naming format and open a new pull request.
- Feel free to ask questions on others' pull requests, even if you are not a reviewer. (You cannot review your own pull request.)

## ACM@UIC Discord Server Invite Link
This server has the #sig-game channel for project discussion: https://discord.gg/Afy6gf4.