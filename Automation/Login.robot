*** Settings ***
Library  SeleniumLibrary

*** Variables ***
${url}  https://www.demoblaze.com/
${browser}  Edge
${wrongusername}    testr420
${wrongpassword}    Android123456
${loginusername}    tester420
${loginpassword}    Android12345
${inuman}


*** Test Cases ***
Verify that the user can successfully login with correct credentials.
    OpenDemoblaze
    click element    //*[@id="login2"]
    sleep   3
    input text  //*[@id="loginusername"]    ${loginusername}
    sleep   1
    input text  //*[@id="loginpassword"]    ${loginpassword}
    sleep   1

Verify that the 'Log in' button functions as intended.
    click button    //*[@id="logInModal"]/div/div/div[3]/button[2]
    sleep   1

Verify that logging in using wrong usernames will prevent the user from logging in with a warning popup.
    sleep   3
    click element   //*[@id="logout2"]
    sleep   1
    click element    //*[@id="login2"]
    sleep   3
    press keys  //*[@id="loginusername"]    CTRL+a  BACKSPACE
    sleep   1
    input text  //*[@id="loginusername"]    ${wrongusername}
    sleep   1
    input text  //*[@id="loginpassword"]    ${loginpassword}
    sleep   1
    click button    //*[@id="logInModal"]/div/div/div[3]/button[2]
    sleep   1
    alert should be present     action=ACCEPT

Verify that logging in using wrong passwords will prevent the user from logging in with a warning popup.
    sleep   3
    press keys  //*[@id="loginusername"]    CTRL+a  BACKSPACE
    sleep   1
    input text  //*[@id="loginusername"]    ${loginusername}
    sleep   1
    press keys  //*[@id="loginpassword"]    CTRL+a  BACKSPACE
    sleep   1
    input text  //*[@id="loginpassword"]    ${wrongpassword}
    sleep   1
    click button    //*[@id="logInModal"]/div/div/div[3]/button[2]
    sleep   1
    alert should be present     action=ACCEPT

Verify that the user is being prevented from logging in if input fields are left blank with a warning popup.
    sleep   3
    press keys  //*[@id="loginusername"]    CTRL+a  BACKSPACE
    sleep   1
    press keys  //*[@id="loginpassword"]    CTRL+a  BACKSPACE
    sleep   1
    click button    //*[@id="logInModal"]/div/div/div[3]/button[2]
    sleep   1
    alert should be present     action=ACCEPT

Verify that the Close button functions as intended.
    sleep   1
    click button    //*[@id="logInModal"]/div/div/div[3]/button[1]

Verify that the 'X' button functions as intended.
    sleep   3
    click element   //*[@id="login2"]
    sleep   1
    click element   //*[@id="logInModal"]/div/div/div[1]/button/span

*** Keywords ***
OpenDemoblaze
    OPEN BROWSER    ${url}     ${browser}
    MAXIMIZE BROWSER WINDOW
    Sleep   3