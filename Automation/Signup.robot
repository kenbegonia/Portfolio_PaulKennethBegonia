*** Settings ***
Library  SeleniumLibrary

*** Variables ***
${url}  https://www.demoblaze.com/
${browser}  Edge
${validusername}    tester425
${validpassword}    Android12345
${loginusername}    tester420
${loginpassword}    Android12345


*** Test Cases ***
Verify that the user is able to input a valid username.
    OpenDemoblaze
    click element    //*[@id="signin2"]
    sleep   3
    input text  //*[@id="sign-username"]    ${validusername}
    sleep   1

Verify that the user is able to input a valid password.
    input text  //*[@id="sign-password"]    ${validpassword}
    sleep   2

Verify that the 'Sign up' button functions as intended.
    click button    //*[@id="signInModal"]/div/div/div[3]/button[2]
    sleep   1

Verify that the user can successfully create an account using valid credentials.
    alert should be present     action=ACCEPT
    sleep   3

Verify that the Close button functions as intended.
    click element    //*[@id="signin2"]
    sleep   1
    click button    //*[@id="signInModal"]/div/div/div[3]/button[1]

Verify that the 'X' button functions as intended.
    click element    //*[@id="signin2"]
    sleep   1
    click element   //*[@id="signInModal"]/div/div/div[1]/button/span

Verify that the user is not able to enter a blank entry on the username field.
    click element    //*[@id="signin2"]
    sleep   3
    press keys  //*[@id="sign-username"]    CTRL+a  BACKSPACE
    sleep   1
    input text  //*[@id="sign-password"]    ${validpassword}
    click button    //*[@id="signInModal"]/div/div/div[3]/button[2]
    sleep   1
    handle alert    ACCEPT
    sleep   1
    click button    //*[@id="signInModal"]/div/div/div[3]/button[1]
    sleep   3

Verify that the user is not able to enter a blank entry on the password field.
    click element    //*[@id="signin2"]
    sleep   3
    input text  //*[@id="sign-username"]    ${validusername}
    sleep   1
    press keys  //*[@id="sign-password"]    CTRL+a  BACKSPACE
    click button    //*[@id="signInModal"]/div/div/div[3]/button[2]
    sleep   1
    handle alert    ACCEPT
    sleep   1
    click button    //*[@id="signInModal"]/div/div/div[3]/button[1]
    sleep   3

Verify that the user is being prevented from creating an account if input fields are left blank with a warning popup.
    click element    //*[@id="signin2"]
    sleep   3
    press keys  //*[@id="sign-username"]    CTRL+a  BACKSPACE
    sleep   1
    press keys  //*[@id="sign-password"]    CTRL+a  BACKSPACE
    click button    //*[@id="signInModal"]/div/div/div[3]/button[2]
    sleep   1
    alert should be present     action=ACCEPT
    sleep   1
    click button    //*[@id="signInModal"]/div/div/div[3]/button[1]
    sleep   3


*** Keywords ***
OpenDemoblaze
    OPEN BROWSER    ${url}     ${browser}
    MAXIMIZE BROWSER WINDOW
    Sleep   3