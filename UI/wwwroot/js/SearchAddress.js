function searchAddress(addressdatamodel) {
    alert(addressdatamodel);
    let editorExtensionId = document.getElementById('extensionAddressId').innerText;
    alert(addressdatamodel.County);
    if (typeof chrome !== "undefined") {
        var jsons = '{"Website_Url":"https://sdat.dat.maryland.gov/RealProperty/Pages/default.aspx","City":"' + addressdatamodel.County + '","PropertyAccountIdentifier":"02","Ward":"' + addressdatamodel.Ward + '","Section":"' + addressdatamodel.Section + '","Block":"' + addressdatamodel.Block + '","Lot":"' + addressdatamodel.Lot + '"}';
        const obj = JSON.parse(jsons);
        let userData = obj;
        chrome.runtime.sendMessage(editorExtensionId, {
            cmd: 'dataRecieved',
            data: userData
        },
            function (response) {
                if (!response.success)
                    console.error("message to extension fail");
            }
        );
    }
    if (addressdatamodel !== null) {
        console.log(`Scraper data called ${addressdatamodel}`);
    }    
}