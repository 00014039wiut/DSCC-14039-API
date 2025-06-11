#!/bin/bash

# Clean previous files
rm -rf /var/www/*
rm -f /etc/systemd/system/webapi.service

# Copy new service file
cp webapi.service /etc/systemd/system/webapi.service

# Reload systemd
systemctl daemon-reexec
systemctl daemon-reload
