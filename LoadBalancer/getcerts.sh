#!/bin/bash

certbot certonly --nginx -d pixelhorrorstudios.com -d www.pixelhorrorstudios.com --non-interactive --agree-tos --email liveordevtrying@gmail.com
certbot certonly --nginx -d discord.pixelhorrorstudios.com -d www.discord.pixelhorrorstudios.com --non-interactive
certbot certonly --nginx -d facebook.pixelhorrorstudios.com -d www.facebook.pixelhorrorstudios.com --non-interactive
certbot certonly --nginx -d gamedev.pixelhorrorstudios.com -d www.gamedev.pixelhorrorstudios.com --non-interactive 
certbot certonly --nginx -d games.pixelhorrorstudios.com -d www.games.pixelhorrorstudios.com --non-interactive
certbot certonly --nginx -d github.pixelhorrorstudios.com -d www.github.pixelhorrorstudios.com --non-interactive
certbot certonly --nginx -d instagram.pixelhorrorstudios.com -d www.instagram.pixelhorrorstudios.com --non-interactive
certbot certonly --nginx -d ivr.pixelhorrorstudios.com --non-interactive
certbot certonly --nginx -d nuget.pixelhorrorstudios.com -d www.nuget.pixelhorrorstudios.com --non-interactive
certbot certonly --nginx -d twitch.pixelhorrorstudios.com -d www.twitch.pixelhorrorstudios.com --non-interactive
certbot certonly --nginx -d youtube.pixelhorrorstudios.com -d www.youtube.pixelhorrorstudios.com --non-interactive
certbot certonly --nginx -d vpn.pixelhorrorstudios.com --non-interactive

certbot certonly --nginx -d api.overlay.pixelhorrorstudios.com --non-interactive
certbot certonly --nginx -d identity.overlay.pixelhorrorstudios.com --non-interactive