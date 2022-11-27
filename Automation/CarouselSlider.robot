*** Settings ***
Library  SeleniumLibrary


*** Variables ***
${url}  https://www.demoblaze.com/
${browser}  Edge


*** Test Cases ***
Verify that the Left button of the Carousel Slider switches to the previous photo slide.
    OpenDemoblaze
    click element   //*[@id="carouselExampleIndicators"]/a[1]

Verify that the Right button of the Carousel Slider switches to the next photo slide.
    click element   //*[@id="carouselExampleIndicators"]/a[2]

Verify that the Right button of the Carousel Slider switches to the first photo slide if the user is on the last photo slide.
    wait until element is enabled   //*[@id="carouselExampleIndicators"]/ol/li[2]
    click element   //*[@id="carouselExampleIndicators"]/a[2]

*** Keywords ***
OpenDemoblaze
    OPEN BROWSER    ${url}     ${browser}
    MAXIMIZE BROWSER WINDOW
    Sleep   3