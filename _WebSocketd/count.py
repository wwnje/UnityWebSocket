#!/usr/bin/env python
# encoding: utf-8
import time
from sys import stdout
i=1
while True:
    time.sleep(1)
    i=i+1
    print(i)
    stdout.flush()