function setThemeCookie(themeName) {
    document.cookie = `currentTheme=${themeName}`;
    console.log(`cookie set as ${themeName}`);
}

function setDarkModeCookie(isDarkMode) {
    document.cookie = `isDarkMode=${isDarkMode}`;
    console.log(`isDarkMode cookie set as ${isDarkMode}`);  
}

function getTheme() {
    console.log(`cookie returned as ${document.cookie}`);
    return document.cookie;
}
function getDarkThemeCookie() {
    console.log(`cookie returned as ${document.cookie}`);
    return document.cookie;
}